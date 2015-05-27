Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms

Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Permissions
Imports System.Timers

Public Class frmMainWindow
    Shared TurnCollection(100) As Turn
    Shared CurrentTurnID As Integer = 0
    Shared CurrentTurnStart As Integer = 1
    
    Shared CurrentGame As Game
    Shared GameCollection(100) As Game
    Shared CurrentGameID As Integer = 0
    Shared CurrentGameIndex As Integer = 0
    Shared CurrentGameStart As Integer = 1

    Shared FriendlyPlayer As String
    Shared FriendlyPlayerID As Integer = 0

    Shared InGameProcessing As Boolean = False
    Shared FileTimer As Timers.Timer = New System.Timers.Timer(2000)
    Shared LoggingPaused As Boolean = False

    Public Shared CardList As New Dictionary(Of String, Card)

    Public Event TurnComplete(ID As Integer)
    Private Sub btnGetTurn_click(sender As Object, e As EventArgs) Handles btnGetTurn.Click
        Dim DesktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        File.Copy("C:\Program Files (x86)\Hearthstone\Hearthstone_Data\output_log.txt", DesktopPath & "\output_log.txt", True)

        cbxTurnList.Items.Add(CurrentTurnID)
    End Sub
    Private Sub ProcessTurnComplete(ID As Integer) Handles Me.TurnComplete
        'MessageBox.Show("Friendly Player is: " & CurrentTurnID)

        'cbxTurnList.Items.AddRange(List)


        ' Application.DoEvents()
        'txtEndBox.Text = "Value"
    End Sub



    Private Sub btnStartLogging_Click(sender As Object, e As EventArgs) Handles btnStartLogging.Click
        'Grab the user-entered player name
        FriendlyPlayer = txtPlayerName.Text
        Dim DesktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        File.Copy("C:\Program Files (x86)\Hearthstone\Hearthstone_Data\output_log.txt", DesktopPath & "\output_log.txt", True)

        'If they didn't enter anything, display message and stop processing
        If IsNothing(FriendlyPlayer) Or FriendlyPlayer.Length = 0 Then
            MessageBox.Show("Friendly Player Name Missing")
            Exit Sub
        End If

        
        'Read the lines of the output log (may not be able to read while game is running)

        Dim lines As String() = File.ReadAllLines(DesktopPath & "\output_log.txt")

        'Find the FriendlyPlayerID in the lines




        FriendlyPlayerID = GetFriendlyPlayerID(lines, 1)

        If FriendlyPlayerID < 0 Then
            MessageBox.Show("Player Name not found in log. Check spelling and make sure you have started a game this session")
            Exit Sub
        End If
        btnStartLogging.Enabled = False
        btnStartLogging.Text = "Logging in Progress"
        txtPlayerName.Enabled = False


        Dim InitialTurn As Turn = New Turn(lines, 0, 1, lines.Length)
        TurnCollection.SetValue(InitialTurn, 0)


        GetCardList()
        ' Hook up the Elapsed event for the timer.  
        'With TurnCollection
        AddHandler FileTimer.Elapsed, AddressOf RunFileCheck
        'End With
        FileTimer.AutoReset = True
        FileTimer.Enabled = True

    End Sub

    Public Sub GetTurnCards(GameID As Integer, TurnID As Integer)
        Dim CurrentTurn As Turn = GameCollection(GameID).turnDetail(TurnID)
        Dim index As Integer = 1
        Dim linedetail As String
        Dim newID As Integer = 0
        Dim newCardID As String
        Dim newCard As Card
        Dim templateCard As Card
        'Dim NewCard As Card = frmMainWindow.CardList("Hero_05")

        If Not IsNothing(CurrentTurn) Then
            'CurrentTurn = turnDetail(TurnID)
            For i As Integer = 0 To CurrentTurn.lines.Length - 2
                linedetail = CurrentTurn.lines(i)
                If linedetail.Contains("name=") And linedetail.Contains("id=") Then
                    index = linedetail.IndexOf("id=")
                    newID = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 3)
                    index = linedetail.IndexOf("cardId=")
                    newCardID = linedetail.Substring(index + 7, linedetail.IndexOf("player=") - index - 8)
                    '
                    'newCard = 
                    templateCard = CardList(newCardID)
                    newCard = templateCard.Clone(newID)

                    index = 1
                End If
            Next
        End If
    End Sub

    Public Sub GetCardList()
        Dim linedetail As String
        Dim DesktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim strArray() As String = File.ReadAllLines(DesktopPath & "\cardlist.txt")

        For i As Integer = 1 To strArray.Length - 1
            linedetail = strArray(i)
            GetCardListDetail(linedetail)

        Next




        'CardArray.SetValue("1", 0)
    End Sub

    Private Sub GetCardListDetail(line As String)
        Dim values() As String = Split(line, vbTab)
        CardList.Add(values(0), New Card With {.ID = values(0), .Name = values(1), .type = values(2), .cost = values(3), .attack = values(4), .health = values(5), .durability = values(6), .text = values(7), .InPlayText = values(8), .Mechanics = values(9), .PlayerClass = values(10), .Race = values(11)})
    End Sub

    Private Function GetFileDate(ByVal FileName As String)
        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo(FileName)
        Dim ModifiedDateTime As DateTime = infoReader.LastWriteTime
        'MsgBox("File was last modified on " & infoReader.LastWriteTime)

        Return ModifiedDateTime


    End Function



    Private Function GetFileLines(filePath As String, startline As Integer, endline As Integer)
        Dim lines As String() = File.ReadAllLines(filePath)
        Dim strArray(endline - startline + 1) As String
        Dim size As Integer = lines.Length
        Dim values As Integer = 0

        Dim linedetail As String
        For i As Integer = startline To endline
            linedetail = lines.GetValue(i - 1)
            If linedetail.Contains("[Power]") Or linedetail.Contains("SubType=ATTACK") Then
                strArray(values) = linedetail
                values = values + 1
            End If
        Next
        Dim cleanArray As String() = RemoveBlanks(strArray)
        Return cleanArray

    End Function


    Private Sub CheckFile(ByVal filePath As String, ByRef TurnID As Integer, ByVal TurnStart As Integer)
        ',ByRef GameID As Integer, ByRef GameStart As Integer
        'Pause file processing
        FileTimer.Enabled = False
        Dim lines As String() = File.ReadAllLines(filePath)
        Dim lastrow As Integer = lines.Length
        'If we aren't currently recording a game, create a new game and reset the flag
        If Not InGameProcessing Then
            'Get the start of the game
            If BlockContains(lines, CurrentGameStart, lastrow, "ConnectAPI.GotoGameServer") > 0 Then
                CurrentGameStart = BlockContains(lines, CurrentGameStart, lastrow, "ConnectAPI.GotoGameServer")
            Else : Exit Sub
            End If

            CurrentGameID = CurrentGameIndex 'GetGameID(lines, CurrentGameStart)
            'CurrentGame.ResetGame()
            'Array.Clear(TurnCollection, 0, TurnCollection.Length)

            Dim NewCollection(101) As Turn
            CurrentGame = New Game(CurrentGameID, FriendlyPlayer, CurrentGameStart, NewCollection)
            'Set the turnID back to 0 and get the new start
            CurrentTurnID = 0
            CurrentTurnStart = CurrentGameStart + 1
            InGameProcessing = True
            FileTimer.Enabled = True
            'Exit this step of processing
            Exit Sub
        End If

        'If we are currently recording a game look for a Turn
        'Find the next start of turn line (or return -1)
        Dim TurnEnd As Integer = BlockContains(lines, TurnStart, lastrow, "TAG_CHANGE Entity=GameEntity tag=TURN value=") - 1
        'Get lines for last game that ended as either win/lost
        Dim GameWonLine As Integer = BlockContains(lines, TurnStart, lastrow, "TAG_CHANGE Entity=" & FriendlyPlayer & " tag=PLAYSTATE value=WON")
        Dim GameLostLine As Integer = BlockContains(lines, TurnStart, lastrow, "TAG_CHANGE Entity=" & FriendlyPlayer & " tag=PLAYSTATE value=LOST")
        'Get the first game end line
        Dim GameEndLine As Integer = NonNegativeMin(GameWonLine, GameLostLine)
        'Get the first either game end or new turn start (-1 if neither found)
        TurnEnd = NonNegativeMin(GameEndLine, TurnEnd)

        'If we have found a new turn or the end of the game do the below
        If TurnEnd > 0 And TurnEnd <> TurnStart Then
            'Get the lines between turn start and end; create Turn object
            Dim values As String() = GetFileLines(filePath, TurnStart, TurnEnd)
            Dim NewTurn As Turn = New Turn(values, TurnID, TurnStart, TurnEnd)

            'Get the details for the turn, store in the object
            NewTurn.GetTurnDetails(FriendlyPlayerID)
            'Add the turn to our game's collection of turns
            CurrentGame.turnDetail.SetValue(NewTurn, TurnID)
            'TurnArray.SetValue(NewTurn, TurnID)

            'If the end of the turn was the end of the game...
            If TurnEnd = GameEndLine Then
                'Get the game details since we are done
                CurrentGame.GetGameDetails(TurnID)
                'Get last cards played
                'CurrentGame.GetTurnCards(TurnID)
                'Trim out blank lines
                CurrentGame.RemoveBlanks()
                'Get the Result
                CurrentGame.GetResult()
                'Update the game information in GameCollection
                GameCollection.SetValue(CurrentGame, CurrentGameIndex)
                'Increment the GameIndex
                CurrentGameIndex += 1
                'Set the game processing flag back to false
                InGameProcessing = False

                CurrentGameStart = TurnEnd + 1
            Else
                'If the end of the turn was not the end of the game do the below
                'Get the Hero information
                If TurnID = 0 Then
                    CurrentGame.GetHeroDetails()
                End If

                'Get the game details so far
                CurrentGame.GetGameDetails(TurnID)
                'Get new cards this turn
                If TurnID > 0 Then
                    CurrentGame.GetTurnCards(TurnID)
                    CurrentGame.GetTurnTagChanges(TurnID)
                    CurrentGame.GetTurnActions(TurnID)
                End If
                'Increment TurnId
                CurrentTurnID = TurnID + 1
                'Update the GameInformation in GameCollection
                GameCollection.SetValue(CurrentGame, CurrentGameIndex)
            End If
            'Starts the file watcher again
            FileTimer.Enabled = True
            'Increment the start line so we don't get caught in a loop
            CurrentTurnStart = TurnEnd + 1
        End If

        FileTimer.Enabled = True
    End Sub

    Private Function BlockContains(ByRef StrArray As String(), startLine As Integer, endLine As Integer, searchString As String)

        Dim line As Integer = startLine
        Dim found As Boolean = False

        While line < endLine And Not found
            Dim lineDetail As String = StrArray.GetValue(line).ToString
            If lineDetail.IndexOf(searchString) > 0 Then
                found = True
                Return line + 1
            End If

            line = line + 1
        End While

        Return -1
    End Function

    Private Function NonNegativeMin(Value1 As Integer, Value2 As Integer)
        If Value1 > 0 And Value2 > 0 Then
            Return Math.Min(Value1, Value2)
        ElseIf Value1 > 0 And Value2 < 0 Then
            Return Value1
        ElseIf Value1 < 0 And Value2 > 0 Then
            Return Value2
        Else
            Return -1
        End If
    End Function

    Private Sub RunFileCheck(sender As Object, e As ElapsedEventArgs)
        Dim DesktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        File.Copy("C:\Program Files (x86)\Hearthstone\Hearthstone_Data\output_log.txt", DesktopPath & "\output_log.txt", True)
        CheckFile(DesktopPath & "\output_log.txt", CurrentTurnID, CurrentTurnStart)

    End Sub

    Private Function FirstBlank(ByVal StrArray As String())
        Dim BlankLine As Integer = -1
        Dim index As Integer = 1
        Dim linedetail As String
        While index < StrArray.Length And BlankLine < 0

            linedetail = StrArray.GetValue(index - 1)

            If linedetail = "" Or IsNothing(linedetail) Then
                BlankLine = index

            End If

            index = index + 1
        End While
        Return BlankLine - 1
    End Function

    Private Function RemoveBlanks(ByVal StrArray As String())
        Dim NewLength As Integer = FirstBlank(StrArray)
        Dim CleanArray(NewLength) As String
        Dim linedetail As String

        For i As Integer = 1 To NewLength
            linedetail = StrArray.GetValue(i - 1)
            CleanArray(i - 1) = linedetail
        Next
        Return CleanArray
    End Function

    Private Function GetFriendlyPlayerID(ByVal StrArray As String(), ByVal StartIndex As Integer)
        Dim ID As Integer = -1
        Dim startPosition As Integer = 1
        Dim index As Integer = StartIndex
        Dim linedetail As String
        While index < StrArray.Length And ID < 0

            linedetail = StrArray.GetValue(index - 1)

            If linedetail.IndexOf("Entity=" & FriendlyPlayer & " tag=PLAYER_ID value=", 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then

                startPosition = linedetail.IndexOf("value=")
                ID = linedetail.Substring(startPosition + 6)

            End If

            index += 1
        End While
        Return ID
        'Entity=zystyl tag=PLAYER_ID value=
    End Function


    Private Function GetGameID(ByVal StrArray As String(), ByVal StartIndex As Integer)
        Dim ID As Integer = -1
        Dim startPosition As Integer = 1
        Dim index As Integer = StartIndex
        Dim linedetail As String
        While index < StrArray.Length And ID < 0

            linedetail = StrArray.GetValue(index - 1)

            If linedetail.IndexOf("ConnectAPI.GotoGameServer") > -1 Then

                startPosition = linedetail.IndexOf("game=")
                ID = linedetail.Substring(startPosition + 5)

            End If

            index += 1
        End While
        Return ID
        'Entity=zystyl tag=PLAYER_ID value=
    End Function


    Private Sub btnCloseProgram_Click(sender As Object, e As EventArgs) Handles btnCloseProgram.Click
        Close()
    End Sub





    Private Sub cbxTurnList_Refresh(sender As Object, e As EventArgs) Handles cbxTurnList.Enter, cbxTurnList.DropDown, cbxTurnList.Click
        cbxTurnList.Items.Clear()
        cbxTurnList.Items.Add("All")

        If cbxGameList.SelectedIndex < 0 Then : Exit Sub
        End If

        If cbxGameList.SelectedIndex > 0 And Not IsNothing(GameCollection(cbxGameList.SelectedIndex - 1)) Then
            Dim MaxTurn As Integer = GameCollection(cbxGameList.SelectedIndex - 1).GetTurnCount()

            For i As Integer = 0 To MaxTurn
                cbxTurnList.Items.Add(i)

            Next
        End If

    End Sub

    Private Sub btnPauseLogging_Click(sender As Object, e As MouseEventArgs) Handles btnPauseLogging.MouseClick
        If Not LoggingPaused Then
            btnPauseLogging.Text = "Resume Logging"
            FileTimer.Enabled = False
            LoggingPaused = True
        Else
            btnPauseLogging.Text = "Pause Logging"
            FileTimer.Enabled = True
        End If
    End Sub

    Private Sub cbxGameList_Refresh(sender As Object, e As EventArgs) Handles cbxGameList.Click, cbxGameList.Enter, cbxGameList.DropDown
        cbxGameList.Items.Clear()
        cbxGameList.Items.Add("")
        If IsNothing(GameCollection(0)) Then
            Exit Sub
        End If



        For i As Integer = 0 To CurrentGameIndex
            If IsNothing(GameCollection(i)) Then
                cbxGameList.Items.Add(i)
            ElseIf GameCollection(i).EnemyClass.Length > 0 And GameCollection(i).FriendlyClass.Length > 0 And GameCollection(i).Result.Length > 0 Then
                cbxGameList.Items.Add(Convert.ToString(i) & " - " & GameCollection(i).FriendlyClass & " vs. " & GameCollection(i).EnemyClass & "(" & GameCollection(i).Result & ")")
            ElseIf GameCollection(i).EnemyClass.Length > 0 And GameCollection(i).FriendlyClass.Length > 0 Then
                cbxGameList.Items.Add(Convert.ToString(i) & " - " & GameCollection(i).FriendlyClass & " vs. " & GameCollection(i).EnemyClass & "(In Progress)")
            Else : cbxGameList.Items.Add(i)
            End If

        Next

    End Sub

    Private Sub cbxGameList_Changed(sender As Object, e As EventArgs) Handles cbxGameList.TextChanged
        If cbxGameList.Text.Length > 0 Then
            cbxTurnList.Enabled = True
            cbxTurnList.Visible = True
            cbxTurnList.Text = "All"

        Else
            cbxTurnList.Enabled = False
            cbxTurnList.Visible = False
            cbxTurnList.Text = ""
            txtCardTarget.Visible = False
            txtNumAttacks.Visible = False
            txtTurnPlayed.Visible = False
            lblNumAttacks.Visible = False
            lblCardTarget.Visible = False
            lblTurnPlayed.Visible = False
            lstCardsPlayed.Items.Clear()
        End If
    End Sub

    Private Sub cbxTurnList_GetData(sender As Object, e As EventArgs) Handles cbxTurnList.SelectedIndexChanged
        Dim GameIndex As Integer = cbxGameList.SelectedIndex - 1

        If cbxTurnList.Text = "All" Then
            Dim gameDetail As Game = GameCollection(GameIndex)

            showAllDetails()
            getGameDetails(gameDetail)
            GetCardsPlayed()
            GetAttacks()
        Else
            Dim TurnIndex As Integer = cbxTurnList.Text
            Dim Details As Turn = GameCollection(GameIndex).turnDetail(TurnIndex)
            If Details.FriendlyTurn Then
                getFriendlyDetails(Details)
            Else : getEnemyDetails(Details)
            End If
            GetCardsPlayed()
            GetAttacks()
        End If

    End Sub

    Private Sub getFriendlyDetails(Details As Turn)
        hideEnemyDetails()

        lblFriendly1.Text = "Friendly"
        lblFriendly2.Text = "Friendly"

        txtFriendlyAT.Text = Details.NumAttacks
        txtFriendlyCD.Text = Details.FriendlyCardsDrawn
        txtFriendlyCP.Text = Details.CardsPlayed
        txtFriendlyHD.Text = 0 'need to implement field in turn class
        txtFriendlyMD.Text = 0 'need to implement field in turn class
        txtFriendlyMDD.Text = Details.FriendlyMinionsDestroyed
        txtFriendlyMP.Text = Details.MinionsPlayed
        txtFriendlyMU.Text = Details.ResourcesUsed
    End Sub

    Private Sub getEnemyDetails(Details As Turn)
        hideEnemyDetails()

        txtEnemyAT.Text = Details.NumAttacks
        txtEnemyCD.Text = Details.EnemyCardsDrawn
        txtEnemyCP.Text = Details.CardsPlayed
        txtEnemyHD.Text = 0 'need to implement field in turn class
        txtEnemyMD.Text = 0 'need to implement field in turn class
        txtEnemyMDD.Text = Details.EnemyMinionsDestroyed
        txtEnemyMP.Text = Details.MinionsPlayed
        txtEnemyMU.Text = Details.ResourcesUsed
    End Sub

    Private Sub hideEnemyDetails()
        txtEnemyAT.Visible = False
        txtEnemyCD.Visible = False
        txtEnemyCP.Visible = False
        txtEnemyHD.Visible = False
        txtEnemyMD.Visible = False
        txtEnemyMDD.Visible = False
        txtEnemyMP.Visible = False
        txtEnemyMU.Visible = False
        lblEnemy1.Visible = False
        lblEnemy2.Visible = False

        lblFriendly1.Text = "Enemy"
        lblFriendly2.Text = "Enemy"
    End Sub

    Private Sub showAllDetails()
        txtEnemyAT.Visible = True
        txtEnemyCD.Visible = True
        txtEnemyCP.Visible = True
        txtEnemyHD.Visible = True
        txtEnemyMD.Visible = True
        txtEnemyMDD.Visible = True
        txtEnemyMP.Visible = True
        txtEnemyMU.Visible = True
        lblEnemy1.Visible = True
        lblEnemy2.Visible = True

        lblFriendly1.Text = "Friendly"
        lblFriendly2.Text = "Friendly"
    End Sub

    Private Sub getGameDetails(Details As Game)
        txtFriendlyAT.Text = Math.Round(Details.FriendlyAttacks / Details.NumFriendlyTurns, 3)
        txtFriendlyCD.Text = Math.Round(Details.FriendlyCardsDrawn / Details.NumFriendlyTurns, 3)
        txtFriendlyCP.Text = Math.Round(Details.FriendlyCardsPlayed / Details.NumFriendlyTurns, 3)
        txtFriendlyHD.Text = Math.Round(Details.FriendlyHeroDamageTaken / Details.NumFriendlyTurns, 3) 'need to implement field in turn class
        txtFriendlyMD.Text = Math.Round(Details.FriendlyMinionDamageTaken / Details.NumFriendlyTurns, 3) 'need to implement field in turn class
        txtFriendlyMDD.Text = Math.Round(Details.FriendlyMinionsDestroyed / Details.NumFriendlyTurns, 3)
        txtFriendlyMP.Text = Math.Round(Details.FriendlyMinionsPlayed / Details.NumFriendlyTurns, 3)
        txtFriendlyMU.Text = Math.Round(Details.FriendlyResourcesUsed / Details.NumFriendlyTurns, 3)

        txtEnemyAT.Text = Math.Round(Details.EnemyAttacks / Details.NumEnemyTurns, 3)
        txtEnemyCD.Text = Math.Round(Details.EnemyCardsDrawn / Details.NumEnemyTurns, 3)
        txtEnemyCP.Text = Math.Round(Details.EnemyCardsPlayed / Details.NumEnemyTurns, 3)
        txtEnemyHD.Text = Math.Round(Details.EnemyHeroDamageTaken / Details.NumEnemyTurns, 3) 'need to implement field in turn class
        txtEnemyMD.Text = Math.Round(Details.EnemyMinionDamageTaken / Details.NumEnemyTurns, 3) 'need to implement field in turn class
        txtEnemyMDD.Text = Math.Round(Details.EnemyMinionsDestroyed / Details.NumEnemyTurns, 3)
        txtEnemyMP.Text = Math.Round(Details.EnemyMinionsPlayed / Details.NumEnemyTurns, 3)
        txtEnemyMU.Text = Math.Round(Details.EnemyResourcesUsed / Details.NumEnemyTurns, 3)
    End Sub

    Public Sub GetCardsPlayed()
        Dim GameDetail As Game = GameCollection(cbxGameList.SelectedIndex - 1)
        Dim SelectedTurn As Integer
        Dim Cards() As Card = GameDetail.CardCollection
        lstCardsPlayed.Items.Clear()
        If cbxTurnList.Text = "All" Then
            For i = 0 To GameDetail.GetCardCount - 1
                If Cards(i).TurnPlayed > 0 Then
                    lstCardsPlayed.Items.Add(Cards(i).Name & " (" & Cards(i).inGameID & ")")
                End If
            Next
        Else
            SelectedTurn = cbxTurnList.Text
            For i = 0 To GameDetail.GetCardCount - 1
                If Cards(i).TurnPlayed = SelectedTurn Then
                    lstCardsPlayed.Items.Add(Cards(i).Name & " (" & Cards(i).inGameID & ")")
                End If
            Next
        End If
    End Sub

    Public Sub GetAttacks()
        Dim GameDetail As Game = GameCollection(cbxGameList.SelectedIndex - 1)
        Dim SelectedTurn As Integer
        Dim Cards() As Card = GameDetail.CardCollection
        lstAttacks.Items.Clear()
        If cbxTurnList.Text = "All" Then
            For i = 0 To GameDetail.GetAttackCount

                lstAttacks.Items.Add(GameDetail.AttackCollection(i).AttackerName & " attacks " & GameDetail.AttackCollection(i).DefenderName)

            Next
        Else
            SelectedTurn = cbxTurnList.Text
            For i = 0 To GameDetail.GetAttackCount
                If GameDetail.AttackCollection(i).Turn = SelectedTurn Then
                    lstAttacks.Items.Add(GameDetail.AttackCollection(i).AttackerName & " attacks " & GameDetail.AttackCollection(i).DefenderName)
                End If
            Next
        End If
    End Sub


    Private Sub lstCardsPlayed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCardsPlayed.SelectedIndexChanged
        Dim selectedCardString As String = lstCardsPlayed.Text
        Dim index As Integer = selectedCardString.IndexOf("(")
        Dim selectedGame As Game = GameCollection(cbxGameList.SelectedIndex - 1)
        Dim selectedID As Integer = selectedCardString.Substring(index + 1, selectedCardString.IndexOf(")") - index - 1)
        Dim selectedCardIndex As Integer = selectedGame.HasCardID(selectedID)
        Dim selectedCard As Card = selectedGame.CardCollection(selectedCardIndex)

        txtCardTarget.Clear()
        txtNumAttacks.Clear()
        txtTurnPlayed.Clear()

        txtCardTarget.Text = selectedCard.CardTarget
        txtNumAttacks.Text = selectedCard.NumAttacks
        txtTurnPlayed.Text = selectedCard.TurnPlayed

        lblNumAttacks.Visible = True

        lblTurnPlayed.Visible = True
        txtNumAttacks.Visible = True
        txtTurnPlayed.Visible = True
        If Not IsNothing(selectedCard.CardTarget) Then
            txtCardTarget.Visible = True
            lblCardTarget.Visible = True
        End If

    End Sub


End Class
