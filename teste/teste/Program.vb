Imports System
Imports System.Math
Imports System.Text

Module Program

    Dim Number As Integer = 2

    Sub Main(args As String())

        Dim binary = TranformarBinario()
        Dim MaxBinary = GetMaxNumBinary(binary)
        Console.WriteLine($"{MaxBinary}")

    End Sub

    Private Function GetMaxNumBinary(binary As String) As String

        Dim maxNum As Integer = 0
        Dim listbinary As New List(Of String)
        For Each item In binary
            listbinary.Add(item)
        Next

        Dim index = 0
        Dim indexMax = listbinary.Count - 1
        While index <= indexMax

            Dim temp = listbinary(index)
            listbinary(index) = listbinary(indexMax)
            listbinary(indexMax) = temp

            Dim TempNumber = BinarioToDecimal(listbinary)

            If maxNum <= TempNumber And TempNumber <> Number Then
                maxNum = TempNumber
            End If

            index += 1

        End While

        Return maxNum.ToString

    End Function

    Private Function BinarioToDecimal(listabinario As List(Of String)) As Integer

        Dim numberDecimal As Integer
        Dim indexMax = listabinario.Count - 1
        Dim numberPow = indexMax

        For index = 0 To indexMax
            numberDecimal += CInt(listabinario(index).ToString) * Pow(2, numberPow)
            numberPow -= 1
        Next

        Return numberDecimal

    End Function

    Private Function TranformarBinario() As String

        Dim numberdecimalActual = Number
        Dim binary As String
        Dim temp As String

        While numberdecimalActual > 0

            temp = numberdecimalActual Mod 2
            numberdecimalActual = Floor(numberdecimalActual / 2)
            binary += temp

        End While

        Return binary.Reverse.ToArray

    End Function

End Module
