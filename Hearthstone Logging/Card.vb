Public Class Card
    Public inGameID As String
    Public ID As String
    Public Name As String
    Public type As String
    Public cost As String
    Public attack As String
    Public health As String
    Public durability As String
    Public text As String
    Public InPlayText As String
    Public Mechanics As String
    Public PlayerClass As String
    Public Race As String
    Public Rarity As String

    Public TurnPlayed As Integer
    Public TurnDestroyed As Integer
    Public NumAttacks As Integer
    Public CardTarget As Integer
    Public PlayerID As Integer
    Public FriendlyCard As Boolean
    Public Attacks(20) As Attack

    Public MaxHP As Integer
    Public CurrentHP As Integer
    Public CurrentAttack As Integer

    Public ActionList(50) As GameAction

    Public Function Clone(newID As Integer)
        Dim NewCard As Card = New Card With {.inGameID = newID, .ID = ID, .Name = Name, .type = type, .cost = cost _
            , .attack = attack, .health = health, .durability = durability, .text = text, .InPlayText = InPlayText _
            , .Mechanics = Mechanics, .PlayerClass = PlayerClass, .Race = Race, .Rarity = Rarity}



        Return NewCard

    End Function



End Class
