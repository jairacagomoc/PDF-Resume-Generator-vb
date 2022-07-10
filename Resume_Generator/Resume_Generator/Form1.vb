Imports Newtonsoft.Json
Imports System.Text
Imports System.IO
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw
Public Class PDFResumeGenerator

    Dim iSubmit As DialogResult
    Dim iExit As DialogResult
    Private ReadOnly JSONpath As String = "C:\Users\63907\Documents\Visual Studio 2019\Resume_Generator\Resume_Generator\bin\Debug\Data\Resume.json"
    Private ReadOnly PDFpath As String = "C:\Users\63907\Documents\Visual Studio 2019\Resume_Generator\Resume_Generator\bin\Debug\Data\Cagomoc,Nina Jaira Lael.pdf"

    Private Sub LoadJson_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadJsonFile.Text = File.ReadAllText(JSONpath)
    End Sub

    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadJsonFile.Clear()
    End Sub

    Private Sub SavePDF_Click(sender As Object, e As EventArgs) Handles Button2.Click
        iSubmit = MessageBox.Show("Convert to PDF?", "PDF Resume Creator", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
        If iSubmit = DialogResult.OK Then
            Dim jsonFromFile As String = File.ReadAllText(JSONpath)
            Dim Outputfromjson As ReadResume = JsonConvert.DeserializeObject(Of ReadResume)(jsonFromFile)
            Dim ConvertPDF As New Document()
            PdfWriter.GetInstance(ConvertPDF, New FileStream(PDFpath, FileMode.Create))
            ConvertPDF.Open()
            Dim separator As New LineSeparator(3.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_CENTER, 1)
            Dim space As New Paragraph(" ")
            Dim fullname As New Paragraph(Outputfromjson.FirstName & Outputfromjson.Surname)
            Dim info1 As New Paragraph(Outputfromjson.Info1)
            Dim info2 As New Paragraph(Outputfromjson.Info2)
            Dim info3 As New Paragraph(Outputfromjson.Info3)
            Dim info4 As New Paragraph(Outputfromjson.Info4)
            Dim about As New Paragraph(Outputfromjson.about)
            Dim birthday As New Paragraph(Outputfromjson.Birthday)
            Dim address As New Paragraph(Outputfromjson.Barangay & Outputfromjson.City & Outputfromjson.Region)
            Dim age As New Paragraph(Outputfromjson.Age)
            Dim email As New Paragraph(Outputfromjson.Email)
            Dim nationality As New Paragraph(Outputfromjson.Nationality)
            Dim school As New Paragraph(Outputfromjson.School)
            Dim school1 As New Paragraph(Outputfromjson.School1)
            Dim yeargraduated As New Paragraph(Outputfromjson.Year_Graduated)
            Dim yeargraduated1 As New Paragraph(Outputfromjson.Year_Graduated1)
            Dim computerliterate As New Paragraph(Outputfromjson.Computer_Literate)
            Dim skill1 As New Paragraph(Outputfromjson.Skill1)
            Dim skill2 As New Paragraph(Outputfromjson.Skill2)
            Dim skill3 As New Paragraph(Outputfromjson.Skill3)
            Dim other As New Paragraph(Outputfromjson.Others)

            info1.Alignment = Element.ALIGN_LEFT
            info2.Alignment = Element.ALIGN_LEFT
            info3.Alignment = Element.ALIGN_LEFT
            info4.Alignment = Element.ALIGN_LEFT
            fullname.Alignment = Element.ALIGN_LEFT
            about.Alignment = Element.ALIGN_LEFT
            birthday.Alignment = Element.ALIGN_LEFT
            address.Alignment = Element.ALIGN_LEFT
            age.Alignment = Element.ALIGN_LEFT
            email.Alignment = Element.ALIGN_LEFT
            nationality.Alignment = Element.ALIGN_LEFT
            school.Alignment = Element.ALIGN_LEFT
            school1.Alignment = Element.ALIGN_LEFT
            yeargraduated.Alignment = Element.ALIGN_LEFT
            yeargraduated1.Alignment = Element.ALIGN_LEFT
            computerliterate.Alignment = Element.ALIGN_LEFT
            skill1.Alignment = Element.ALIGN_LEFT
            skill2.Alignment = Element.ALIGN_LEFT
            skill3.Alignment = Element.ALIGN_LEFT
            other.Alignment = Element.ALIGN_LEFT


            ConvertPDF.Add(fullname)
            ConvertPDF.Add(space)
            ConvertPDF.Add(separator)

            ConvertPDF.Add(info1)
            ConvertPDF.Add(about)
            ConvertPDF.Add(space)
            ConvertPDF.Add(separator)

            ConvertPDF.Add(info2)
            ConvertPDF.Add(address)
            ConvertPDF.Add(birthday)
            ConvertPDF.Add(age)
            ConvertPDF.Add(email)
            ConvertPDF.Add(nationality)
            ConvertPDF.Add(space)
            ConvertPDF.Add(separator)

            ConvertPDF.Add(info3)
            ConvertPDF.Add(school)
            ConvertPDF.Add(school1)
            ConvertPDF.Add(yeargraduated)
            ConvertPDF.Add(yeargraduated1)
            ConvertPDF.Add(space)
            ConvertPDF.Add(separator)

            ConvertPDF.Add(info4)
            ConvertPDF.Add(computerliterate)
            ConvertPDF.Add(skill1)
            ConvertPDF.Add(skill2)
            ConvertPDF.Add(skill3)
            ConvertPDF.Add(other)

            MessageBox.Show("Converted to PDF Successfully!")
            ConvertPDF.Close()
        Else
            'do nothing 
        End If
    End Sub

    Private Sub Exit_Click(sender As Object, e As EventArgs) Handles Button4.Click
        iExit = MessageBox.Show("Do you want to exit? ", "PDF Resume Creator", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If iExit = DialogResult.Yes Then
            Application.Exit()
        Else
            'do nothing
        End If
    End Sub
End Class
Public Class ReadResume
    Public Property Info1 As String
    Public Property Info2 As String
    Public Property Info3 As String
    Public Property Info4 As String
    Public Property FirstName As String
    Public Property Surname As String
    Public Property about As String
    Public Property Barangay As String
    Public Property City As String
    Public Property Region As String
    Public Property Birthday As String
    Public Property Age As String
    Public Property Email As String
    Public Property Nationality As String
    Public Property School As String
    Public Property Year_Graduated As String
    Public Property School1 As String
    Public Property Year_Graduated1 As String
    Public Property Computer_Literate As String
    Public Property Skill1 As String
    Public Property Skill2 As String
    Public Property Skill3 As String
    Public Property Others As String

End Class
