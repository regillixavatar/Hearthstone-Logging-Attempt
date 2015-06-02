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
    Public CardDictionary As New Dictionary(Of Integer, Card)
    Public AttackCollection(100) As Attack
    Public ActionCollection(250) As GameAction
    Public ActionDictionary As New Dictionary(Of Integer, Object)
    Public ActionCount As Integer = 0



    'Create a new game with the specified ID, player name, and collection of turns
    Public Sub New(ID As Integer, FriendlyName As String, Start As Integer, TurnArray As Turn())
        GameID = ID
        FriendlyPlayerName = FriendlyName
        StartLine = Start
        turnDetail = TurnArray



    End Sub

    Public Sub GetTurnCards(TurnID As Integer)
        'This subroutine attempts to gather all the cards in the turn and assign them to the game as well
        Dim CurrentTurn As Turn
        Dim index As Integer = 1
        Dim linedetail As String
        Dim newID As Integer = 0
        Dim newCardID As String
        Dim newCard As Card
        Dim templateCard As Card

        'If we actually have something in the turn
        If Not IsNothing(turnDetail(TurnID)) Then
            'Grab the turn object we are currently working with 
            CurrentTurn = turnDetail(TurnID)
            'Read every non-blank line in the turn
            For i As Integer = 0 To CurrentTurn.lines.Length - 2
                linedetail = CurrentTurn.lines(i)
                'If the line has the card name and ID
                If linedetail.Contains("Network+Entity+Tag") Then
                    'get the indicies for collecting ID
                    If linedetail.Contains("cardId= type=INVALID") Or Right(linedetail, 7).Equals("dstPos=") Then
                        Dim Keep As String = "Going"
                    Else
                        index = linedetail.IndexOf("id=")
                        'get the in-game ID of the card
                        'minor fix to stop type exceptions
                        If linedetail.IndexOf("cardId=") < linedetail.IndexOf("zone=") Then
                            newID = linedetail.Substring(index + 3, linedetail.IndexOf("cardId=") - index - 3)
                            'get the CardID for the spotted card
                            index = linedetail.IndexOf("cardId=")
                            newCardID = linedetail.Substring(index + 7, linedetail.IndexOf("name=") - index - 8)
                        Else
                            newID = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 3)
                            'get the CardID for the spotted card
                            index = linedetail.IndexOf("cardId=")
                            newCardID = linedetail.Substring(index + 7, linedetail.IndexOf("player=") - index - 8)
                        End If
                        
                        'Use the card dictionary to create a template card and then clone it
                        templateCard = frmMainWindow.CardList(newCardID)
                        newCard = templateCard.Clone(newID)
                        newCard.PlayerID = linedetail.Substring(linedetail.IndexOf("player=") + 7, 1)

                        If HasCardID(newID) = -1 And Not CardDictionary.ContainsKey(newID) Then
                            CardCollection(GetCardCount() + 1) = newCard
                            CardDictionary.Add(newCard.inGameID, newCard)
                        End If
                    End If

                ElseIf linedetail.Contains("DebugPrintPower") And linedetail.Contains("SHOW_ENTITY") And Not linedetail.Contains("Entity=[name=") Then

                    If linedetail.Contains("Entity=[") And Not linedetail.Contains("Entity=[name=") Then
                        index = linedetail.IndexOf("id=")
                        newID = linedetail.Substring(index + 3, linedetail.IndexOf("cardId=") - index - 4)

                    Else
                        index = linedetail.IndexOf("Entity=")
                        newID = linedetail.Substring(index + 7, linedetail.IndexOf("CardID=") - index - 8)
                    End If


                    index = linedetail.IndexOf("CardID=")
                    newCardID = linedetail.Substring(index + 7)

                    templateCard = frmMainWindow.CardList(newCardID)
                    newCard = templateCard.Clone(newID)

                    If HasCardID(newID) = -1 And Not CardDictionary.ContainsKey(newID) Then
                        CardCollection(GetCardCount() + 1) = newCard
                        CardDictionary.Add(newCard.inGameID, newCard)
                    ElseIf CardDictionary.ContainsKey(newID) Then
                        'CardCollection(HasCardID(newID)).Name = newCard.Name
                        'CardDictionary(newID).Name = newCard.Name
                    End If

                ElseIf linedetail.Contains("name=") And linedetail.Contains("id=") And Not linedetail.Contains("cardId= type=INVALID") Then
                    'get the indicies for collecting ID
                    index = linedetail.IndexOf("id=")
                    'get the in-game ID of the card
                    newID = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 3)

                    index = linedetail.IndexOf("cardId=")
                    'get the CardID for the spotted card
                    newCardID = linedetail.Substring(index + 7, linedetail.IndexOf("player=") - index - 8)
                    'Use the card dictionary to create a template card and then clone it
                    templateCard = frmMainWindow.CardList(newCardID)
                    newCard = templateCard.Clone(newID)
                    newCard.PlayerID = linedetail.Substring(linedetail.IndexOf("player=") + 7, 1)

                    If HasCardID(newID) = -1 And Not CardDictionary.ContainsKey(newID) Then
                        CardCollection(GetCardCount() + 1) = newCard
                        CardDictionary.Add(newCard.inGameID, newCard)
                    ElseIf CardDictionary.ContainsKey(newID) Then
                        'CardCollection(HasCardID(newID)).Name = newCard.Name
                        'CardDictionary(newID).Name = newCard.Name
                    End If
                End If
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

    Public Sub GetTurnActions(TurnID As Integer)
        'Collects all the Actions (Play, Power, Death, Trigger, Attack) into our ActionCollection (maybe dictionary someday)
        Dim CurrentTurn As Turn
        Dim index As Integer = 1
        Dim linedetail As String
        Dim updateID As String = ""
        Dim cardIndex As Integer
        'Dim updateName As String

        If Not IsNothing(turnDetail(TurnID)) Then
            'If the specified turn exists get the details
            CurrentTurn = turnDetail(TurnID)

            For i As Integer = 0 To CurrentTurn.lines.Length - 2
                linedetail = CurrentTurn.lines(i)
                'If it is a generic trigger (unused currently) ignore the line
                If linedetail.Contains("SubType=TRIGGER Index=-1") Then
                ElseIf linedetail.Contains("SubType=DEATHS") Then
                ElseIf linedetail.Contains("zone=SECRET") Then
                ElseIf linedetail.Contains("SubType=") Or linedetail.Contains("TAG_CHANGE Entity=GameEntity tag=TURN value=") Then
                    Dim NewAction As New GameAction(linedetail, i, GameID, TurnID)

                    cardIndex = HasCardID(NewAction.ActionCard)

                    'cardIndex = HasCardID(updateID)

                    If NewAction.ActionType.Equals("Play") And CardDictionary.ContainsKey(NewAction.ActionCard) Then
                        Dim CardDetail As Card = CardDictionary(NewAction.ActionCard)
                        'Dim CardDetail As Card = CardCollection(cardIndex)
                        Dim ResourceLine As String = CurrentTurn.lines(i + 1)


                        'Dim ResourcesUsed As Integer = ResourceLine.Substring(ResourceLine.IndexOf("value=") + 6)
                        GetActionLines(NewAction, TurnID, i)
                        NewAction.TextDescription = CardDetail.Name & " (" & CardDetail.inGameID & ") was played for " '& ResourcesUsed
                    ElseIf NewAction.ActionType.Equals("Power") And CardDictionary.ContainsKey(NewAction.ActionCard) Then
                        Dim CardDetail As Card = CardDictionary(NewAction.ActionCard)
                        GetActionLines(NewAction, TurnID, i)
                        NewAction.TextDescription = CardDetail.Name & " (" & CardDetail.inGameID & ") brings mighty power"
                    ElseIf NewAction.ActionType.Equals("Trigger") And CardDictionary.ContainsKey(NewAction.ActionCard) Then
                        Dim CardDetail As Card = CardDictionary(NewAction.ActionCard)
                        GetActionLines(NewAction, TurnID, i)
                        NewAction.TextDescription = CardDetail.Name & " (" & CardDetail.inGameID & ") triggered"
                    ElseIf NewAction.ActionType.Equals("Attack") And CardDictionary.ContainsKey(NewAction.ActionCard) Then
                        GetActionLines(NewAction, TurnID, i)
                        NewAction.TextDescription = NewAction.AttackerName & " (" & NewAction.AttackerID & ") attacks " _
                            & NewAction.DefenderName & " (" & NewAction.DefenderID & ")"
                        'ElseIf NewAction.ActionType.Equals("Deaths") And cardIndex > -1 Then
                        '    GetActionLines(NewAction, TurnID, i)
                        '    NewAction.TextDescription = "Deaths of many kinds"
                        'ElseIf NewAction.ActionType.Equals("Trigger") And cardIndex > -1 Then
                        'GetActionLines(NewAction, TurnID, i)
                        NewAction.lines(0) = linedetail
                        'Dim CardDetail As Card = CardCollection(cardIndex)
                        'NewAction.TextDescription = CardDetail.Name & " (" & CardDetail.inGameID & ") triggered"

                    End If
                    NewAction.RemoveBlanks()
                    ActionCollection(ActionCount) = NewAction
                    ActionCount += 1
                ElseIf linedetail.Contains("Network+Entity+Tag") And linedetail.Contains("entity=") And linedetail.Contains("zone=PLAY") And Not Right(linedetail, 7).Equals("dstPos=") Then
                    Dim NewAction As New GameAction(linedetail, i, GameID, TurnID)
                    cardIndex = HasCardID(NewAction.ActionCard)

                    'Dim CardDetail As Card = CardCollection(cardIndex)
                    cardIndex = HasCardID(NewAction.ActionCard)
                    'Dim CardDetail As Card = CardCollection(cardIndex)
                    'NewAction.TextDescription = CardDetail.Name & " (" & CardDetail.inGameID & ") summoned"
                    NewAction.RemoveBlanks()
                    ActionCollection(ActionCount) = NewAction
                    ActionCount += 1

                End If
            Next
        End If
    End Sub

    

    Public Sub GetActionLines(ByRef UpdateAction As GameAction, ByVal TurnID As Integer, ByVal StartLine As Integer)
        Dim inSubAction As Boolean = False
        Dim inDeaths As Boolean = False
        Dim DeathCount As Integer = 0
        Dim DeathLine As String
        Dim FoundEnd As Boolean
        Dim currentIndex As Integer = StartLine + 1
        Dim elementCount As Integer = 1
        Dim linedetail As String

        Dim index As Integer
        Dim indexName As Integer
        Dim updateID As Integer
        Dim updateName As String

        While Not FoundEnd And currentIndex < turnDetail(TurnID).lines.Length - 1
            linedetail = turnDetail(TurnID).lines(currentIndex)

            If inSubAction Then
                If linedetail.Contains("ACTION_END") Then : inSubAction = False
                End If
            ElseIf inDeaths Then
                If linedetail.Contains("tag=ZONE value=GRAVEYARD") Then
                    index = linedetail.IndexOf("id=")
                    indexName = linedetail.IndexOf("name=")
                    updateID = linedetail.Substring(index + 3, linedetail.IndexOf("zone=") - index - 4)
                    updateName = linedetail.Substring(indexName + 5, index - indexName - 6)
                    'ActionDictionary(ActionCount).Add()
                    UpdateAction.Deaths(DeathCount) = updateName & " (" & updateID & ")" & " died"
                    DeathCount += 1
                ElseIf linedetail.Contains("ACTION_END") Then
                    inDeaths = False
                    If UpdateAction.ActionType.Equals("Attack") Then
                        FoundEnd = True
                    End If
                End If

            Else
                If linedetail.Contains("SubType=DEATHS") Then
                    inDeaths = True
                ElseIf linedetail.Contains("ACTION_START") Then
                    inSubAction = True
                ElseIf linedetail.Contains("-" & Space(UpdateAction.NumSpaces) & "ACTION_END") Then
                    UpdateAction.lines(elementCount) = linedetail
                    DeathLine = turnDetail(TurnID).lines(currentIndex + 1)
                    elementCount += 1
                    If UpdateAction.ActionType = "Attack" And DeathLine.Contains("-" & Space(UpdateAction.NumSpaces) & "ACTION_START") And DeathLine.Contains("SubType=DEATHS") Then
                        UpdateAction.lines(elementCount) = DeathLine
                        elementCount += 1
                    Else : FoundEnd = True
                    End If
                Else
                    UpdateAction.lines(elementCount) = linedetail
                    elementCount += 1
                End If
            End If

            currentIndex += 1
        End While


    End Sub



    Public Function HasCardID(ID As Integer)
        ' Dim index As Integer = -1
        If IsNothing(CardCollection) Then
            Return -1
        End If
        For i As Integer = 0 To GetCardCount() - 1
            If CardCollection(i).inGameID = ID Then
                Dim Keep As String = "on"
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

    Public Function GetActionCount()
        Dim BlankLine As Integer = -1
        Dim index As Integer = 1
        Dim ActionLine As GameAction

        If ActionCollection.Length < 100 Then
            Return ActionCollection.Length - 2
        End If

        While index < ActionCollection.Length And BlankLine < 0

            ActionLine = ActionCollection.GetValue(index - 1)

            If IsNothing(ActionLine) Then
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
