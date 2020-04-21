
Imports System.Text.RegularExpressions

Public Class Form1
    Private Sub txtpercentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpercentaje.KeyPress

        'Dim rex As Regex = New Regex("^(\d+\d+|\d+[.]\d+\d)|(100.00)%?$")
        'Dim match As Match = rex.Match(txtpercentaje.Text)
        'If match.Success Then
        '    e.Handled = True
        'End If
        e.Handled = Not ValidaCaracter(e.KeyChar)
    End Sub

    Private Function ValidaCaracter(ByVal Character As Char) As Boolean

        If Character = vbBack Then 'Valida si es tecla borrar
            Return True
        End If

        If Character = "."c Then
            Return PuntoValido()
        End If

        If Char.IsNumber(Character) Then 'Valida si es numero
            Return ValorValido(Character)
        End If

        Return False
    End Function

    Function ValorValido(ByVal Character As Char) As Boolean
        If Not TienePunto() Then
            If EsDecimo() Then
                If Not EsCentecimo() Then
                    If Character = "0" Then
                        Return True
                    End If
                End If
            Else
                If txtpercentaje.Text.Length < 2 Then
                    Return True
                End If
            End If

        Else
            If txtpercentaje.Text.Split(".")(1).Length <= 1 Then
                Return True
            End If
        End If

        Return False
    End Function

    Private Function EsDecimo() As Boolean
        Return txtpercentaje.Text.StartsWith("10")
    End Function

    Private Function EsCentecimo() As Boolean
        Return txtpercentaje.Text.StartsWith("100")
    End Function

    Function PuntoValido() As Boolean
        If TienePunto() Then
            Return False
        End If

        If txtpercentaje.Text.Length <= 3 And txtpercentaje.Text.Length > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function TienePunto() As Boolean
        Return txtpercentaje.Text.Contains(".")
    End Function

End Class
