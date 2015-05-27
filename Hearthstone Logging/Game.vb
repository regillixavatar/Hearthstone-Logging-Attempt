Public Class Game

    Public turnDetail As Turn()
    Public GameID As Integer
    Public StartLine As Integer
    Public EndLine As Integer
    Public Result As String = ""



    Public DamageTaken As Integer = 0

    Public NumFriendlyTurns As Integer = 0
    Public FriendlyPlayerName As String
    Public FriendlyHeroID As Integer = 0
    Public FriendlyHeroCardID As String
    Public FriendlyClass As String
    Public FriendlyCardsPlayed As Integer = 0
    Public FriendlyMinionsPlayed As Integer = 0
    Public FriendlyCardsDrawn As Integer = 0
    Public FriendlyResourcesUsed As Integer = 0
    Public FriendlyAttacks As Integer = 0
    Public FriendlyDamageTaken As Integer = 0
    Public FriendlyHeroDamageTaken As Integer = 0
    Public FriendlyMinionDamageTaken As Integer = 0
    Public FriendlyMinionsDestroyed As Integer = 0

    Public NumEnemyTurns As Integer = 0
    Public EnemyPlayerName As String
    Public EnemyHeroID As Integer = 0
    Public EnemyHeroCardID As String
    Public EnemyClass As String
    Public EnemyCardsPlayed As Integer = 0
    Public EnemyMinionsPlayed As Integer = 0
    Public EnemyCardsDrawn As Integer = 0
    Public EnemyResourcesUsed As Integer = 0
    Public EnemyAttacks As Integer = 0
    Public EnemyDamageTaken As Integer = 0
    Public EnemyHeroDamageTaken As Integer = 0
    Public EnemyMinionDamageTaken As Integer = 0
    Public EnemyMinionsDestroyed As Integer = 0

    Public CardCollection(100) As Card
    Public AttackCollection(100) As Attack
    Public ActionCollection(100) As Object
    Public ActionDictionary As New Dictionary(Of Integer, Object)
    Public ActionCount As Integer = 0




    Public Sub New(ID As Integer, FriendlyName As String, Start As Integer, TurnArray As Turn())
        GameID = ID
        FriendlyPlayerName = FriendlyName
        StartLine = Start
        turnDetail = TurnArray

    End Sub

    Public Sub GetTurnCards(TurnID As Integer)
        Dim CurrentTurn As Turn
        Dim index As Integer = 1
        Dim linedetail As String
        Dim newID As Integer = 0
        Dim newCardID As String
        Dim newCard As Card
        Dim templateCard As Card
        'Dim NewCard As Card = frmMainWindow.CardList("Hero_05")

        If Not IsNothing(turnDetail(TurnID)) Then
            CurrentTurn = turnDetail(TurnID)
            For i As Integer = 0 To CurrentTurn.lines.Length - 2
                linedetail = CurrentTurn.lines(i)
                If linedetail.Contains("name=") And linedetail.Contains("id=") And Not linedetail.Contains("cardId= type=INVALID") Then
                    index = linedetail.IndexOf("id=")
                    newID = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 3)
                    index = linedetail.IndexOf("cardId=")
                    newCardID = linedetail.Substring(index + 7, linedetail.IndexOf("player=") - index - 8)
                    templateCard = frmMainWindow.CardList(newCardID)
                    newCard = templateCard.Clone(newID)
                    newCard.PlayerID = linedetail.Substring(linedetail.IndexOf("player=") + 7, 1)

                    If HasCardID(newID) = -1 Then
                        CardCollection(GetCardCount() + 1) = newCard
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub GetTurnActions(TurnID As Integer)
        Dim CurrentTurn As Turn
        Dim index As Integer = 1
        Dim linedetail As String
        Dim updateID As String
        Dim cardIndex As Integer
        Dim updateName As String

        If Not IsNothing(turnDetail(TurnID)) Then
            CurrentTurn = turnDetail(TurnID)
            For i As Integer = 0 To CurrentTurn.lines.Length - 2
                linedetail = CurrentTurn.lines(i)
                If linedetail.Contains("SubType=TRIGGER Index=-1") Then
                ElseIf linedetail.Contains("SubType=") And linedetail.Contains("Entity=[name=") Then
                    index = linedetail.IndexOf("id=")
                    updateID = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 4)
                    cardIndex = HasCardID(updateID)

                    If cardIndex > -1 And linedetail.Contains("SubType=PLAY") Then
                        Dim CardDetail As Card = CardCollection(cardIndex)
                        Dim ResourceLine As String = CurrentTurn.lines(i + 1)
                        Dim ResourcesUsed As Integer = ResourceLine.Substring(ResourceLine.IndexOf("value=") + 6)
                        ActionCollection(ActionCount) = CardDetail.Name & " (" & CardDetail.inGameID & ") was played for " & ResourcesUsed
                        ActionCount += 1
                    ElseIf cardIndex > -1 And linedetail.Contains("SubType=ATTACK") Then
                        Dim newAttack As New Attack(linedetail, TurnID)
                        ActionCollection(ActionCount) = newAttack.AttackerName & " (" & newAttack.AttackerID & ") attacks " _
                            & newAttack.DefenderName & " (" & newAttack.DefenderID & ")"
                        ActionCount += 1

                        'Commented below for now, may add back later
                        'AttackCollection(AttackIndex) = newAttack
                    ElseIf cardIndex > -1 And linedetail.Contains("SubType=TRIGGER") Then
                        Dim CardDetail As Card = CardCollection(cardIndex)
                        ActionCollection(ActionCount) = CardDetail.Name & " (" & CardDetail.inGameID & ") triggered"
                    
                    End If
                ElseIf linedetail.Contains("SubType=") And linedetail.Contains("Entity=[id=") Then
                    index = linedetail.IndexOf("id=")
                    updateID = linedetail.Substring(index + 3, linedetail.IndexOf("cardId=") - index - 4)
                    cardIndex = HasCardID(updateID)

                    If cardIndex > -1 And linedetail.Contains("SubType=PLAY") Then
                        Dim CardDetail As Card = CardCollection(cardIndex)
                        Dim ResourceLine As String = CurrentTurn.lines(i + 1)
                        Dim ResourcesUsed As Integer = ResourceLine.Substring(ResourceLine.IndexOf("value=") + 6)
                        ActionCollection(ActionCount) = CardDetail.Name & " (" & CardDetail.inGameID & ") was played for " & ResourcesUsed
                        ActionCount += 1
                    ElseIf cardIndex > -1 And linedetail.Contains("SubType=ATTACK") Then
                        Dim newAttack As New Attack(linedetail, TurnID)
                        ActionCollection(ActionCount) = newAttack.AttackerName & " (" & newAttack.AttackerID & ") attacks " _
                            & newAttack.DefenderName & " (" & newAttack.DefenderID & ")"
                        ActionCount += 1
                    ElseIf cardIndex > -1 And linedetail.Contains("SubType=TRIGGER") Then
                        Dim CardDetail As Card = CardCollection(cardIndex)
                        ActionCollection(ActionCount) = CardDetail.Name & " (" & CardDetail.inGameID & ") triggered"
                    End If
                ElseIf linedetail.Contains("SubType=DEATHS") Then
                    Dim DeathIndex As Integer = i + 1
                    While Not linedetail.Contains("ACTION_END")
                        linedetail = CurrentTurn.lines(DeathIndex)
                        If linedetail.Contains("tag=ZONE value=GRAVEYARD") Then
                            index = linedetail.IndexOf("id=")
                            Dim indexName As Integer = linedetail.IndexOf("name=")
                            updateID = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 4)
                            updateName = linedetail.Substring(indexName + 5, index - indexName - 6)
                            'ActionDictionary(ActionCount).Add()
                            ActionCollection(ActionCount) = updateName & " (" & updateID & ")" & " died"
                            ActionCount += 1
                        End If
                        DeathIndex += 1
                    End While
                    'TAG_CHANGE Entity=[name=Leeroy Jenkins id=32 zone=PLAY zonePos=2 cardId=EX1_116 player=1] tag=ZONE value=GRAVEYARD
                ElseIf linedetail.Contains("TAG_CHANGE Entity=GameEntity tag=TURN value=") Then
                    'ActionDictionary(ActionCount).Add("Start of Turn: " & TurnID)
                    ActionCollection(ActionCount) = "Start of Turn: " & TurnID
                    ActionCount += 1
                End If
                '[Power] GameState.DebugPrintPower() - ACTION_START Entity=[name=Ironbeak Owl id=39 zone=HAND zonePos=2 cardId=CS2_203 player=2] SubType=PLAY Index=0 Target=[name=Sludge Belcher id=24 zone=PLAY zonePos=1 cardId=FP1_012 player=1]
                '[Power] GameState.DebugPrintPower() - ACTION_START Entity=[id=24 cardId= type=INVALID zone=HAND zonePos=5 player=1] SubType=PLAY Index=0 Target=0
            Next

        End If
    End Sub

    Public Sub GetTurnTagChanges(TurnID As Integer)
        Dim CurrentTurn As Turn
        Dim index As Integer = 1
        Dim linedetail As String
        Dim updateID As String
        Dim cardIndex As Integer
        If Not IsNothing(turnDetail(TurnID)) Then
            CurrentTurn = turnDetail(TurnID)
            For i As Integer = 0 To CurrentTurn.lines.Length - 2
                linedetail = CurrentTurn.lines(i)
                'If there is no name yet process it one way
                If linedetail.Contains("TAG_CHANGE Entity=[id=") Then
                    index = linedetail.IndexOf("id=")
                    updateID = linedetail.Substring(index + 3, linedetail.IndexOf("cardId=") - index - 3)
                    cardIndex = HasCardID(updateID)
                    If cardIndex > -1 And linedetail.Contains("tag=NUM_ATTACKS_THIS_TURN value=1") Then
                        CardCollection(cardIndex).NumAttacks += 1
                    ElseIf cardIndex > -1 And linedetail.Contains("tag=CARD_TARGET value=") Then
                        CardCollection(cardIndex).CardTarget = linedetail.Substring(linedetail.IndexOf("value=") + 6)
                    End If
                    'If there is a name process it the other
                ElseIf linedetail.Contains("TAG_CHANGE Entity=[name=") Then
                    index = linedetail.IndexOf("id=")
                    updateID = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 4)
                    cardIndex = HasCardID(updateID)
                    If cardIndex > -1 And linedetail.Contains("tag=NUM_ATTACKS_THIS_TURN value=") And Not linedetail.Contains("value=0") Then
                        CardCollection(cardIndex).NumAttacks += 1
                    ElseIf cardIndex > -1 And linedetail.Contains("tag=CARD_TARGET value=") Then
                        CardCollection(cardIndex).CardTarget = linedetail.Substring(linedetail.IndexOf("value=") + 6)
                    End If
                ElseIf linedetail.Contains("SubType=ATTACK") Then
                    Dim newAttack As New Attack(linedetail, TurnID)
                    index = linedetail.IndexOf("id=")
                    updateID = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 4)
                    cardIndex = HasCardID(updateID)

                    Dim AttackIndex As Integer = GetAttackCount() + 1
                    Dim newthing As String = "this"
                    AttackCollection(AttackIndex) = newAttack
                ElseIf linedetail.Contains("tag=LAST_CARD_PLAYED value=") Then
                    index = linedetail.IndexOf("value=")
                    updateID = linedetail.Substring(index + 6)
                    cardIndex = HasCardID(updateID)
                    If cardIndex > -1 Then
                        CardCollection(cardIndex).TurnPlayed = TurnID
                    End If

                End If
            Next
        End If

    End Sub

    Public Function HasCardID(ID As Integer)
        ' Dim index As Integer = -1
        If IsNothing(CardCollection) Then
            Return -1
        End If
        For i As Integer = 0 To GetCardCount() - 1
            If CardCollection(i).inGameID = ID Then
                Return i
            End If
        Next
        Return -1
    End Function

    Public Sub GetGameDetails(TurnID As Integer)
        Dim CurrentTurn As Turn
        Dim index As Integer = 1
        'Dim NewCard As Card = frmMainWindow.CardList("Hero_05")

        If Not IsNothing(turnDetail(TurnID)) Then
            CurrentTurn = turnDetail(TurnID)
            If CurrentTurn.FriendlyTurn Then
                NumFriendlyTurns += 1
                FriendlyCardsPlayed += CurrentTurn.CardsPlayed
                FriendlyMinionsPlayed += CurrentTurn.MinionsPlayed
                FriendlyCardsDrawn += CurrentTurn.FriendlyCardsDrawn
                FriendlyResourcesUsed += CurrentTurn.ResourcesUsed
                FriendlyAttacks += CurrentTurn.NumAttacks
                FriendlyDamageTaken += CurrentTurn.FriendlyDamageTaken
                FriendlyMinionsDestroyed += CurrentTurn.FriendlyMinionsDestroyed
            Else
                NumEnemyTurns += 1
                EnemyCardsPlayed += CurrentTurn.CardsPlayed
                EnemyMinionsPlayed += CurrentTurn.MinionsPlayed
                EnemyCardsDrawn += CurrentTurn.EnemyCardsDrawn
                EnemyResourcesUsed += CurrentTurn.ResourcesUsed
                EnemyAttacks += CurrentTurn.NumAttacks
                EnemyDamageTaken += CurrentTurn.EnemyDamageTaken
                EnemyMinionsDestroyed += CurrentTurn.EnemyMinionsDestroyed
            End If
            index += 1
        End If


    End Sub


    Public Sub ResetDetails()


    End Sub
    Public Sub GetResult()
        Dim LastTurn As Turn = turnDetail(turnDetail.Length - 2)
        Dim index As Integer = 1
        Dim lineDetail As String = LastTurn.lines(LastTurn.lines.Length - 2)
        Dim startPosition As Integer = lineDetail.IndexOf("value=")
        Result = lineDetail.Substring(startPosition + 6)

    End Sub
    Public Function GetCardCount()
        Dim BlankLine As Integer = -1
        Dim index As Integer = 1
        Dim CardLine As Card

        If CardCollection.Length < 100 Then
            Return CardCollection.Length - 2
        End If

        While index < CardCollection.Length And BlankLine < 0

            CardLine = CardCollection.GetValue(index - 1)

            If IsNothing(CardLine) Then
                BlankLine = index - 1

            End If

            index = index + 1
        End While
        Return BlankLine - 1
    End Function


    Public Function GetAttackCount()
        Dim BlankLine As Integer = -1
        Dim index As Integer = 1
        Dim TurnLine As Attack

        If AttackCollection.Length < 100 Then
            Return AttackCollection.Length - 2
        End If

        While index < AttackCollection.Length And BlankLine < 0

            TurnLine = AttackCollection.GetValue(index - 1)

            If IsNothing(TurnLine) Then
                BlankLine = index - 1

            End If

            index = index + 1
        End While
        Return BlankLine - 1
    End Function

    Public Function GetTurnCount()
        Dim BlankLine As Integer = -1
        Dim index As Integer = 1
        Dim TurnLine As Turn

        If turnDetail.Length < 100 Then
            Return turnDetail.Length - 2
        End If

        While index < turnDetail.Length And BlankLine < 0

            TurnLine = turnDetail.GetValue(index - 1)

            If IsNothing(TurnLine) Then
                BlankLine = index - 1

            End If

            index = index + 1
        End While
        Return BlankLine - 1
    End Function

    Public Sub RemoveBlanks()
        Dim NewLength As Integer = GetTurnCount() + 1
        Dim CleanArray(NewLength) As Turn
        Dim TurnLine As Turn
        For i As Integer = 1 To NewLength
            TurnLine = turnDetail.GetValue(i - 1)
            CleanArray(i - 1) = TurnLine
        Next

        Dim NewCardLength As Integer = GetCardCount() + 1
        Dim CleanCardArray(NewCardLength) As Card
        Dim CardLine As Card
        For j As Integer = 1 To NewCardLength
            CardLine = CardCollection.GetValue(j - 1)
            CleanCardArray(j - 1) = CardLine
        Next

        turnDetail = CleanArray
        CardCollection = CleanCardArray
    End Sub

    Public Sub GetHeroDetails()
        If turnDetail(0).lines.Length > 0 Then
            Dim ID1 As Integer = -1
            Dim ID2 As Integer = -1
            Dim CardID1 As String = ""
            Dim CardID2 As String = ""
            Dim startPosition As Integer = 1
            Dim cardIDstartPosition As Integer = 1
            Dim index As Integer = 1
            Dim StrArray() As String = turnDetail(0).lines
            Dim linedetail As String

            Dim FirstFound As Boolean = False
            Dim SecondFound As Boolean = False

            'Start from the beginning and get the two Hero IDs
            While index < StrArray.Length And Not (FirstFound And SecondFound)
                linedetail = StrArray.GetValue(index - 1)
                If linedetail.Contains("Creating ID=") And linedetail.Contains("CardID=HERO_") Then
                    startPosition = linedetail.IndexOf("ID=")
                    cardIDstartPosition = linedetail.IndexOf("CardID=")
                    If Not FirstFound Then
                        ID1 = linedetail.Substring(startPosition + 3, 1)
                        CardID1 = linedetail.Substring(cardIDstartPosition + 7)
                        FirstFound = True
                    ElseIf Not SecondFound Then

                        ID2 = linedetail.Substring(startPosition + 3, 1)
                        ID2 = linedetail.Substring(startPosition + 3, linedetail.IndexOf("CardID=") - startPosition - 4)
                        CardID2 = linedetail.Substring(cardIDstartPosition + 7)
                        SecondFound = True
                    End If
                End If
                'Creating ID=4 CardID=HERO_
                'TAG_CHANGE Entity=zystyl tag=HERO_ENTITY value=36
                index += 1
            End While

            'Reset the found flags and set the index to the end of the file
            FirstFound = False
            SecondFound = False
            index = StrArray.Length - 1
            'Start at the end of the file to find which player is which ID (and what Class)
            While index > 0 And Not (FirstFound And SecondFound)
                linedetail = StrArray.GetValue(index - 1)
                If linedetail.Contains("TAG_CHANGE Entity=") And linedetail.Contains("tag=HERO_ENTITY value=" & ID1) And Not FirstFound Then
                    'startPosition = linedetail.IndexOf("value=")
                    If linedetail.IndexOf("TAG_CHANGE Entity=" & FriendlyPlayerName, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                        FriendlyHeroID = ID1
                        FriendlyHeroCardID = CardID1
                        FirstFound = True
                    Else
                        EnemyHeroID = ID1
                        EnemyHeroCardID = CardID1
                        startPosition = linedetail.IndexOf("Entity=")
                        EnemyPlayerName = linedetail.Substring(startPosition + 7, linedetail.IndexOf("tag=") - startPosition - 8)
                        FirstFound = True
                    End If


                ElseIf linedetail.Contains("TAG_CHANGE Entity=") And linedetail.Contains("tag=HERO_ENTITY value=" & ID2) And Not SecondFound Then
                    'startPosition = linedetail.IndexOf("value=")
                    If linedetail.IndexOf("TAG_CHANGE Entity=" & FriendlyPlayerName, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                        FriendlyHeroID = ID2
                        FriendlyHeroCardID = CardID2
                        SecondFound = True
                    Else
                        EnemyHeroID = ID2
                        EnemyHeroCardID = CardID2
                        startPosition = linedetail.IndexOf("Entity=")
                        EnemyPlayerName = linedetail.Substring(startPosition + 7, linedetail.IndexOf("tag=") - startPosition - 8)
                        SecondFound = True
                    End If



                End If
                index -= 1
            End While

            Dim ClassList() As String = {"", "Warrior", "Shaman", "Rogue", "Paladin", "Hunter", "Druid", "Warlock", "Mage", "Priest"}
            FriendlyClass = ClassList(Right(FriendlyHeroCardID, 1))
            EnemyClass = ClassList(Right(EnemyHeroCardID, 1))
        End If
    End Sub

End Class
