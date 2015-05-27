Public Class Turn
    Public lines As String()
    Public GameID As Integer
    Public ID As Integer
    Public StartLine As Integer
    Public EndLine As Integer

    Public FriendlyTurn As Boolean = 0
    Public NumAttacks As Integer = 0
    Public DamageTaken As Integer = 0
    Public FriendlyDamageTaken As Integer = 0
    Public EnemyDamageTaken As Integer = 0
    Public FriendlyMinionsDestroyed As Integer = 0
    Public EnemyMinionsDestroyed As Integer = 0

    Public Resources As Integer = 0
    Public ResourcesUsed As Integer = 0
    Public FriendlyCardsDrawn As Integer = 0
    Public EnemyCardsDrawn As Integer = 0

    Public CardsPlayed As Integer = 0
    Public MinionsPlayed As Integer

    Public CardsPlayedList As String = ""



    Public Sub New(ByVal TurnLines As String(), ByVal TurnID As Integer, ByVal TurnStartLine As Integer, ByVal TurnEndLine As Integer)
        lines = TurnLines
        ID = TurnID
        StartLine = TurnStartLine
        EndLine = TurnEndLine


    End Sub



    Public Sub GetTurnDetails(FriendlyPlayerID)
        Dim linedetail As String
        Dim startPosition As Integer
        Dim intTagValue As Integer
        Dim strTagValue As String
        'Collect information on each time of line
        For i As Integer = 1 To lines.Length - 1
            linedetail = lines.GetValue(i - 1)
            startPosition = linedetail.IndexOf("value=")
            If IsNumeric(linedetail.Substring(startPosition + 6)) Then
                intTagValue = linedetail.Substring(startPosition + 6)
            Else : strTagValue = linedetail.Substring(startPosition + 6)
            End If


            'If it is a damage line, add to the turn total (need to correct Weapons taking durability dmg)
            If linedetail.Contains("tag=PREDAMAGE value=") And linedetail.Contains("[Power]") Then
                DamageTaken += intTagValue
                'If it is a friendly character taking damage, add to friendly damage
                If linedetail.Contains("player=" & FriendlyPlayerID & "]") Then
                    FriendlyDamageTaken += intTagValue
                    'Else add to enemy damage
                Else : EnemyDamageTaken += intTagValue
                End If

                'Increment total number of attacks (just adding 1 each time for nonzero line to correct for windfury)
            ElseIf linedetail.Contains("tag=NUM_ATTACKS_THIS_TURN value=") And linedetail.Contains("[Power]") And Not linedetail.Contains("value=0") Then 'NUM_ATTACKS_THIS_TURN
                NumAttacks += 1
                'If it is a resource total line, update the value. There should only be one per turn
            ElseIf linedetail.Contains("tag=RESOURCES value=") And linedetail.Contains("[Power]") Then
                Resources = intTagValue
                'If it is a resource amount used line, update/replace the value
            ElseIf linedetail.Contains("tag=RESOURCES_USED value=") And linedetail.Contains("[Power]") Then
                ResourcesUsed = intTagValue
                'If it is a minions killed this turn, replace the current value
            ElseIf linedetail.Contains("TAG_CHANGE Entity=zystyl tag=NUM_FRIENDLY_MINIONS_THAT_DIED_THIS_TURN value=") And linedetail.Contains("[Power]") Then
                FriendlyMinionsDestroyed = intTagValue
            ElseIf linedetail.Contains("tag=NUM_FRIENDLY_MINIONS_THAT_DIED_THIS_TURN value=") And linedetail.Contains("[Power]") Then
                EnemyMinionsDestroyed = intTagValue
            ElseIf linedetail.Contains("TAG_CHANGE Entity=zystyl tag=NUM_CARDS_DRAWN_THIS_TURN value=") And linedetail.Contains("[Power]") Then
                FriendlyCardsDrawn = intTagValue
            ElseIf linedetail.Contains("tag=NUM_CARDS_DRAWN_THIS_TURN value=") And linedetail.Contains("[Power]") Then
                EnemyCardsDrawn = intTagValue
            ElseIf linedetail.Contains("tag=NUM_CARDS_PLAYED_THIS_TURN value=") And linedetail.Contains("[Power]") Then
                CardsPlayed = intTagValue
            ElseIf linedetail.Contains("tag=NUM_MINIONS_PLAYED_THIS_TURN value=") And linedetail.Contains("[Power]") Then
                MinionsPlayed = intTagValue
                'MinionsPlayed
            ElseIf linedetail.Contains("TAG_CHANGE Entity=zystyl tag=TURN_START value=") And linedetail.Contains("[Power]") Then
                FriendlyTurn = True

            End If

        Next

        'Public FriendlyTurn As Boolean = 0
        'Public FriendlyMinionsDestroyed As Integer = 0
        'Public EnemyMinionsDestroyed As Integer = 0

        'NUM_CARDS_DRAWN_THIS_TURN
        'NUM_CARDS_PLAYED_THIS_TURN
        'NUM_FRIENDLY_MINIONS_THAT_DIED_THIS_TURN
        'NUM_MINIONS_KILLED_THIS_TURN
        'NUM_MINIONS_PLAYED_THIS_TURN
        'NUM_MINIONS_PLAYER_KILLED_THIS_TURN
        'NUM_TIMES_HERO_POWER_USED_THIS_GAME

    End Sub

    Public Sub GetThisTurnValues()

    End Sub

    Public Sub GetCardsPlayed()

    End Sub


End Class

