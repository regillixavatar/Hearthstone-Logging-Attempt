
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Permissions
Imports System.Timers
Module HearthstoneMainModule
    '**************************** Module Header ******************************\
    ' Module Name:  HearthstoneMainModule.vb
    ' Project:      HearthstoneLogging
    ' Copyright (c) Microsoft Corporation.
    ' 
    '**************************************************************************/




    Friend Class MainModule

        Shared TurnCollection(100) As Turn
        Shared CurrentTurnID As Integer = 0
        Shared CurrentTurnStart As Integer = 1

        Shared FriendlyPlayer As String = "zystyl"
        Shared FriendlyPlayerID As Integer = 0

        Shared Sub Main()

            'GetFileDate("C:\Program Files (x86)\Hearthstone\Hearthstone_Data\output_log.txt")

            Dim lines As String() = File.ReadAllLines("C:\Program Files (x86)\Hearthstone\Hearthstone_Data\output_log.txt")
            Dim InitialTurn As Turn = New Turn(lines, 0, 1, lines.Length)

            TurnCollection.SetValue(InitialTurn, 0)
            FriendlyPlayerID = GetFriendlyPlayerID(lines)
            Console.WriteLine("Friendly Player is: " & FriendlyPlayerID)

            Dim FileTimer As Timer = New System.Timers.Timer(1000)
            ' Hook up the Elapsed event for the timer.  
            With TurnCollection
                AddHandler FileTimer.Elapsed, AddressOf RunFileCheck
            End With
            FileTimer.AutoReset = True
            FileTimer.Enabled = True

            'CheckFile("C:\Program Files (x86)\Hearthstone\Hearthstone_Data\output_log.txt", 2, 30364, TurnCollection)
            'CheckFile("C:\Program Files (x86)\Hearthstone\Hearthstone_Data\output_log.txt", 2, 30364, TurnCollection)

            While Chr(Console.Read()) <> "q"c
            End While






            'previous change time, previous change line; current change time, current change line




        End Sub


        Private Shared Function GetFileDate(ByVal FileName As String)
            Dim infoReader As System.IO.FileInfo
            infoReader = My.Computer.FileSystem.GetFileInfo(FileName)
            Dim ModifiedDateTime As DateTime = infoReader.LastWriteTime
            'MsgBox("File was last modified on " & infoReader.LastWriteTime)

            Return ModifiedDateTime


        End Function



        Private Shared Function GetFileLines(filePath As String, startline As Integer, endline As Integer)
            Dim lines As String() = File.ReadAllLines(filePath)
            'Dim lines As String() = File.ReadAllLines("C:\Users\Michael\Desktop\working_output_log.txt")


            Dim strArray(endline - startline + 1) As String
            Dim size As Integer = lines.Length
            Dim values As Integer = 0

            Dim linedetail As String
            For i As Integer = startline To endline

                linedetail = lines.GetValue(i - 1)

                If linedetail.Contains("[Power]") Then
                    strArray(values) = linedetail
                    values = values + 1
                End If
            Next

            'Dim cleanArray As String() = RemoveBlanks(strArray)
            'Dim linedetail As String = lines.GetValue(startline)

            'Dim strList As List(Of String) = strArray.ToList
            'strArray.RemoveAll(Function(str) String.IsNullOrEmpty(str))
            'strList.RemoveAll(Function(str) String.IsNullOrWhiteSpace(str))

            Dim cleanArray As String() = RemoveBlanks(strArray)

            Return cleanArray

        End Function


        Private Shared Sub CheckFile(ByVal filePath As String, ByRef TurnID As Integer, ByVal TurnStart As Integer, ByVal TurnArray As Turn())
            ',ByRef GameID As Integer, ByRef GameStart As Integer

            Dim lines As String() = File.ReadAllLines(filePath)
            'Dim lastrow As Integer = File.ReadAllLines(filePath).Length
            Dim lastrow As Integer = lines.Length
            Dim TurnEnd As Integer = BlockContains(lines, TurnStart, lastrow)

            If TurnEnd > 0 And TurnEnd <> TurnStart Then

                Dim values As String() = GetFileLines(filePath, TurnStart, TurnEnd)


                Dim NewTurn As Turn = New Turn(values, TurnID, TurnStart, TurnEnd)

                TurnArray.SetValue(NewTurn, TurnID)

                NewTurn.GetTurnDetails(FriendlyPlayerID)

                'NewTurn.PrintLines()

                CurrentTurnID = TurnID + 1
                CurrentTurnStart = TurnEnd + 1
            Else : Console.WriteLine("turn not found")
            End If

            'Dim blankvalues As String() = GetFileLines(filePath, 1, 10)


        End Sub

        Private Shared Function BlockContains(ByRef StrArray As String(), startLine As Integer, endLine As Integer)

            Dim line As Integer = startLine
            Dim found As Boolean = False

            While line < endLine And Not found
                Dim lineDetail As String = StrArray.GetValue(line).ToString
                If lineDetail.IndexOf("TAG_CHANGE Entity=GameEntity tag=TURN value=") > 0 Then
                    found = True
                    Return line
                End If

                line = line + 1
            End While

            Return -1
        End Function

        Private Shared Sub RunFileCheck(sender As Object, e As ElapsedEventArgs)
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime)
            CheckFile("C:\Program Files (x86)\Hearthstone\Hearthstone_Data\output_log.txt", CurrentTurnID, CurrentTurnStart, TurnCollection)
        End Sub

        Private Shared Function FirstBlank(ByVal StrArray As String())
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

        Private Shared Function RemoveBlanks(ByVal StrArray As String())
            Dim NewLength As Integer = FirstBlank(StrArray)
            Dim CleanArray(NewLength) As String
            Dim linedetail As String

            For i As Integer = 1 To NewLength

                linedetail = StrArray.GetValue(i - 1)

                CleanArray(i - 1) = linedetail


            Next


            Return CleanArray
        End Function

        Private Shared Function GetFriendlyPlayerID(ByVal StrArray As String())
            Dim ID As Integer = -1
            Dim startPosition As Integer = 1
            Dim index As Integer = 1
            Dim linedetail As String
            While index < StrArray.Length And ID < 0

                linedetail = StrArray.GetValue(index - 1)

                If linedetail.Contains("Entity=zystyl tag=PLAYER_ID value=") Then

                    startPosition = linedetail.IndexOf("value=")
                    ID = linedetail.Substring(startPosition + 6)

                End If

                index = index + 1
            End While
            Return ID
            'Entity=zystyl tag=PLAYER_ID value=
        End Function



    End Class









End Module
