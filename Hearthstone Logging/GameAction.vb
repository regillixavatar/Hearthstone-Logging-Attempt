Public Class GameAction
    Public ActionType As String
    Public ActionCard As Integer 'in game ID of card that spawned the action
    Public StartLine As Integer
    Public EndLine As Integer
    Public ActionTurn As Integer
    Public lines(100) As String
    Public Turn As Integer
    Public NumSpaces As Integer

    Public TextDescription As String

    Public AttackerID As Integer
    Public AttackerCardID As String
    Public AttackerName As String
    Public DefenderID As Integer
    Public DefenderCardID As String
    Public DefenderName As String

    Public AttackerDamageTaken As Integer
    Public AttackerHPRemaining As Integer
    Public AttackerDestroyed As Boolean
    Public DefenderDamageTaken As Integer
    Public DefenderHPRemaining As Integer
    Public DefenderDestroyed As Integer



    Public Deaths(25) As String

    Public Sub New(linedetail As String, CurrentLine As Integer, GameID As Integer, TurnID As Integer)
        'Dim CurrentTurn As Turn
        Dim index As Integer = 1
        'Dim updateID As String
        'Dim cardIndex As Integer
        'Dim updateName As String

        If linedetail.Contains("SubType=ATTACK") Then
            'This subroutine processes a single text line that has an attack in it (like below). It will pull attacker and defneder info together into a new Attack object
            '[Power] GameState.DebugPrintPower() - ACTION_START Entity=[name=Mad Scientist id=12 zone=PLAY zonePos=1 cardId=FP1_004 player=1] SubType=ATTACK Index=-1 Target=[name=Malfurion Stormrage id=36 zone=PLAY zonePos=0 cardId=HERO_06 player=2]

            'Grab the indices for important Attacker information in the string
            Dim indexName As Integer = linedetail.IndexOf("name=")
            Dim indexID As Integer = linedetail.IndexOf("id=")
            Dim indexZone As Integer = linedetail.IndexOf("zone=")
            Dim indexCardID As Integer = linedetail.IndexOf("cardId=")
            Dim indexPlayer As Integer = linedetail.IndexOf("player=")
            Dim indexAttack As Integer = linedetail.IndexOf("SubType=ATTACK")

            Dim CurrentGame As Integer = GameID
            ActionType = "Attack"
            'Grab the important attacker information in the string
            AttackerID = linedetail.Substring(indexID + 3, indexZone - indexID - 4)
            AttackerCardID = linedetail.Substring(indexCardID + 7, indexPlayer - indexCardID - 8)
            AttackerName = linedetail.Substring(indexName + 5, indexID - indexName - 6)
            ActionCard = AttackerID
            'Move the indices forward so that we get the important defender information in the string
            indexName = linedetail.IndexOf("name=", indexAttack)
            indexID = linedetail.IndexOf("id=", indexAttack)
            indexZone = linedetail.IndexOf("zone=", indexAttack)
            indexCardID = linedetail.IndexOf("cardId=", indexAttack)
            indexPlayer = linedetail.IndexOf("player=", indexAttack)

            'Grab the important defender information in the string
            DefenderID = linedetail.Substring(indexID + 3, indexZone - indexID - 4)
            DefenderCardID = linedetail.Substring(indexCardID + 7, indexPlayer - indexCardID - 8)
            DefenderName = linedetail.Substring(indexName + 5, indexID - indexName - 6)

            StartLine = CurrentLine
            lines(0) = linedetail
            Turn = TurnID
            'ElseIf linedetail.Contains("tag=ZONE value=GRAVEYARD") Then
            'index = linedetail.IndexOf("id=")
            'Dim indexName As Integer = linedetail.IndexOf("name=")
            'ActionCard = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 4)

            'linedetail.Contains("SubType=DEATHS") Then
        ElseIf linedetail.Contains("SubType=PLAY") Then
            'Dim CardDetail As Card = frmMainWindow.CardList(cardIndex)
            'Dim ResourceLine As String = CurrentTurn.lines(1 + 1)
            'Dim ResourcesUsed As Integer = ResourceLine.Substring(ResourceLine.IndexOf("value=") + 6)
            If linedetail.Contains("Entity=[id=") Then
                index = linedetail.IndexOf("id=")
                ActionType = "Play"
                ActionCard = linedetail.Substring(index + 3, linedetail.IndexOf("cardId=") - index - 4)
                StartLine = CurrentLine
                lines(0) = linedetail
                Turn = TurnID
            Else
                index = linedetail.IndexOf("id=")
                ActionType = "Play"
                ActionCard = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 4)
                StartLine = CurrentLine
                lines(0) = linedetail
                Turn = TurnID
            End If
            'cardIndex = HasCardID(updateID)
        ElseIf linedetail.Contains("SubType=POWER") Then
            If linedetail.Contains("Entity=[id=") Then
                index = linedetail.IndexOf("id=")
                ActionType = "Power"
                ActionCard = linedetail.Substring(index + 3, linedetail.IndexOf("cardId=") - index - 4)
                StartLine = CurrentLine
                lines(0) = linedetail
                Turn = TurnID
            Else
                index = linedetail.IndexOf("id=")
                ActionType = "Power"
                ActionCard = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 4)
                StartLine = CurrentLine
                lines(0) = linedetail
                Turn = TurnID
            End If
        ElseIf linedetail.Contains("SubType=TRIGGER") Then
            index = linedetail.IndexOf("id=")
            ActionType = "Trigger"
            ActionCard = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 4)
            Dim CardName As String = linedetail.Substring(linedetail.IndexOf("name=") + 5, index - linedetail.IndexOf("name=") - 6)
            lines(0) = linedetail
            StartLine = CurrentLine
            Turn = TurnID
            TextDescription = CardName & " (" & ActionCard & ")" & " Triggered"
            'ElseIf linedetail.Contains("SubType=DEATHS") Then
            '    ActionType = "Deaths"
            '    StartLine = CurrentLine
            '    lines(0) = linedetail
            'Turn = TurnID
        ElseIf linedetail.Contains("TAG_CHANGE Entity=GameEntity tag=TURN value=") Then
            ActionType = "Turn Start"
            ActionCard = -1
            StartLine = CurrentLine
            lines(0) = linedetail
            Turn = TurnID
            TextDescription = "Start of Turn " & TurnID
        ElseIf linedetail.Contains("Network+Entity+Tag") And linedetail.Contains("entity=") And linedetail.Contains("zone=PLAY") And Not Right(linedetail, 7).Equals("dstPos=") Then
            ActionType = "Token Summon"
            index = linedetail.IndexOf("id=")
            ActionCard = linedetail.Substring(index + 3, linedetail.IndexOf("cardId=") - index - 4)
            index = linedetail.IndexOf("name=")
            Dim CardName As String = linedetail.Substring(index + 5, linedetail.IndexOf("]", index) - index - 6)
            StartLine = CurrentLine
            lines(0) = linedetail
            Turn = TurnID
            TextDescription = "Token " & CardName & " (" & ActionCard & ")" & " Summoned"
            '[Zone] ZoneChangeList.ProcessChanges() - processing index=1 change=powerTask=[power=[type=FULL_ENTITY entity=[id=70 cardId=FP1_002t name=Spectral Spider] tags=System.Collections.Generic.List`1[Network+Entity+Tag]] complete=False] entity=[name=Spectral Spider id=70 zone=PLAY zonePos=1 cardId=FP1_002t player=1] srcZoneTag=INVALID srcPos= dstZoneTag=PLAY dstPos=1
            '%Network+Entity+Tag%entity=%zone=PLAY%' AND Data NOT LIKE '%dstPos='
        End If

        NumSpaces = linedetail.IndexOf("ACTION_START") - linedetail.IndexOf("-") - 1


    End Sub

    Public Sub GetActionDetails()
        If ActionType.Equals("Attack") Then

        End If
    End Sub

    Public Function GetActionCount()
        Dim BlankLine As Integer = -1
        Dim index As Integer = 1
        Dim linedetail As String

        If lines.Length < 100 Then
            Return lines.Length - 2
        End If

        While index < lines.Length And BlankLine < 0

            linedetail = lines.GetValue(index - 1)

            If IsNothing(linedetail) Then
                BlankLine = index - 1

            End If

            index = index + 1
        End While
        Return BlankLine - 1
    End Function

    Public Sub RemoveBlanks()
        Dim NewLength As Integer = GetActionCount() + 1
        Dim CleanArray(NewLength) As String
        Dim TurnLine As String
        For i As Integer = 1 To NewLength
            TurnLine = lines.GetValue(i - 1)
            CleanArray(i - 1) = TurnLine
        Next


        lines = CleanArray
    End Sub

End Class
