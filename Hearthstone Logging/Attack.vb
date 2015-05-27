Public Class Attack
    Inherits GameAction
    Public AttackerID As Integer
    Public AttackerCardID As String
    Public AttackerName As String
    Public DefenderID As Integer
    Public DefenderCardID As String
    Public DefenderName As String

    Public AttackerDamageTaken As Integer = 0
    Public AttackerHPRemaining As Integer = 0
    Public AttackerDestroyed As Boolean = 0
    Public DefenderDamageTaken As Integer = 0
    Public DefenderHPRemaining As Integer = 0
    Public DefenderDestroyed As Integer = 0

    Public Turn

    Public Sub New(linedetail As String, TurnID As Integer)
        'This subroutine processes a single text line that has an attack in it (like below). It will pull attacker and defneder info together into a new Attack object
        '[Power] GameState.DebugPrintPower() - ACTION_START Entity=[name=Mad Scientist id=12 zone=PLAY zonePos=1 cardId=FP1_004 player=1] SubType=ATTACK Index=-1 Target=[name=Malfurion Stormrage id=36 zone=PLAY zonePos=0 cardId=HERO_06 player=2]

        'Grab the indices for important Attacker information in the string
        Dim indexName As Integer = linedetail.IndexOf("name=")
        Dim indexID As Integer = linedetail.IndexOf("id=")
        Dim indexZone As Integer = linedetail.IndexOf("zone=")
        Dim indexCardID As Integer = linedetail.IndexOf("cardId=")
        Dim indexPlayer As Integer = linedetail.IndexOf("player=")
        Dim indexAttack As Integer = linedetail.IndexOf("SubType=ATTACK")

        'Grab the important attacker information in the string
        AttackerID = linedetail.Substring(indexID + 3, indexZone - indexID - 4)
        AttackerCardID = linedetail.Substring(indexCardID + 7, indexPlayer - indexCardID - 8)
        AttackerName = linedetail.Substring(indexName + 5, indexID - indexName - 6)

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

        Turn = TurnID
    End Sub

End Class
