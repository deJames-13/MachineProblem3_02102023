Public Class Form1
    ' COMPUTE
    Private Sub btnCompute_Click(sender As Object, e As EventArgs) Handles btnCompute.Click
        Dim fHrs, fOverTime, fGross, fNet, fPayGrade, fDeduc, fTaxRate, fRegWage, fTaxDue As Double
        fOverTime = 0
        Dim SSS As Double = 200
        Dim PAG_IBIG As Double = 100
        Dim strPos As String = ""
        Dim strPayGrade As String = txtPaygr2.Text.ToUpper()

        If (Not IsNumeric(txtHrs2.Text)) Then
            MsgBox("Invalid numeric input!", MessageBoxIcon.Warning, "Invalid Input")
            Return
        ElseIf Not (strPayGrade = "A" OrElse strPayGrade = "B") Then
            MsgBox("Please choose a paygrade A or B!", MessageBoxIcon.Warning, "Pay Grade unknown!")
            txtPaygr2.Focus()
            txtPaygr2.Text = ""
            Return
        End If

        Select Case txtPos1.Text.ToUpper()
            Case "M"
                strPos = "Messenger"
                fTaxRate = 0.05
                If strPayGrade = "A" Then
                    fPayGrade = 5500
                Else
                    fPayGrade = 6500
                End If
            Case "E"
                strPos = "Encode"
                fTaxRate = 0.06
                If strPayGrade = "A" Then
                    fPayGrade = 6500
                Else
                    fPayGrade = 7500
                End If
            Case "T"
                strPos = "Technician"
                fTaxRate = 0.07
                If strPayGrade = "A" Then
                    fPayGrade = 7500
                Else
                    fPayGrade = 8500
                End If
            Case "P"
                strPos = "Programmer"
                fTaxRate = 0.08
                If strPayGrade = "A" Then
                    fPayGrade = 10000
                Else
                    fPayGrade = 10500
                End If
            Case "S"
                strPos = "System Analyst"
                fTaxRate = 0.09
                fPayGrade = 12500
            Case Else
                MsgBox("Invalid position code! Valid Codes are M-E-T-P-S", MessageBoxIcon.Warning, "Unknown Position")
                txtPos1.Text = ""
                txtPos1.Focus()
                Return
        End Select

        fHrs = txtHrs2.Text
        fRegWage = fPayGrade / 160
        If fHrs > 160 Then
            fOverTime = (fHrs - 160) * fRegWage * 1.5
        End If
        fGross = fHrs * fRegWage + fOverTime
        fTaxDue = fTaxRate * fGross
        fDeduc = SSS + PAG_IBIG
        fNet = fGross - (fDeduc + fTaxDue)

        txtSal2.Text = fPayGrade.ToString("C2")
        txtName3.Text = txtName1.Text
        txtPos3.Text = strPos
        txtHrs3.Text = fHrs
        txtOT3.Text = fOverTime.ToString("C2")
        txtDeduc3.Text = fDeduc.ToString("c2")
        txtGross3.Text = fGross.ToString("c2")
        txtNet3.Text = fNet.ToString("C2")
    End Sub
    ' CLEAR
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim m As Integer = MessageBox.Show("Are you sure you want to clear the form?", "Clear Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If m = 7 Then
            Return
        End If
        ' Box 1
        txtName1.Text = ""
        txtDep1.Text = ""
        txtComp1.Text = ""
        txtPos1.Text = ""
        ' Box 2
        txtHrs2.Text = ""
        txtPaygr2.Text = ""
        txtSal2.Text = ""
        ' Box 3
        txtName3.Text = ""
        txtPos3.Text = ""
        txtHrs3.Text = ""
        txtOT3.Text = ""
        txtDeduc3.Text = ""
        txtGross3.Text = ""
        txtNet3.Text = ""
    End Sub
    ' EXIT
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim m As Integer = MessageBox.Show("Are you sure you want to exit?", "Exitting Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If m = 7 Then
            Return
        End If
        Me.Close()
    End Sub

End Class
