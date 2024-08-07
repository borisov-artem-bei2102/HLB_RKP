using System;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HLP_RKP_LR1.Models;

namespace HLP_RKP_LR2.Models
{
    public class WordDocumentCreator
    {
        private const string DEFAULT_FONT_SIZE = "28";

        public static void CreateDocument(string filePath, string fileName)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath + fileName, WordprocessingDocumentType.Document))
            {
                Body body = CreateBody(wordDocument);
                AddBold(body, "Отчет о пациентах");
                AddTable(body);
                SaveDocument(wordDocument);
            }
        }

        private static Body CreateBody(WordprocessingDocument doc)
        {
            MainDocumentPart mainPart = doc.AddMainDocumentPart();
            mainPart.Document = new Document();
            Body body = mainPart.Document.AppendChild(new Body());
            return body;
        }

        private static void SaveDocument(WordprocessingDocument doc)
        {
            doc.MainDocumentPart.Document.Save();
        }

        private static Paragraph GetParagraph(string content, OpenXmlElement[] runParams, OpenXmlElement[] paragraphParams)
        {
            RunProperties runProps = new RunProperties();
            Run run = new Run();
            runProps.Append(runParams);
            run.Append(runProps);
            run.Append(new Text(content));
            Paragraph p = new Paragraph();
            ParagraphProperties paragraphProps = new ParagraphProperties();
            paragraphProps.Append(paragraphParams);
            p.Append(paragraphProps);
            p.Append(run);
            return p;
        }

        private static OpenXmlElement[] GetParams(params OpenXmlElement[] props)
        {
            return props;
        }

        private static FontSize GetFontSize(string fontSize)
        {
            return new FontSize() { Val = fontSize };
        }

        private static Justification GetCentered()
        {
            return new Justification() { Val = JustificationValues.Center };
        }

        private static void AddBold(Body body, string content, string fontSize = DEFAULT_FONT_SIZE)
        {
            Paragraph p = GetParagraph(content, GetParams(GetFontSize(fontSize), new Bold()), GetParams());
            body.AppendChild(p);
        }

        private static void AddPlain(Body body, string content, string fontSize = DEFAULT_FONT_SIZE)
        {
            Paragraph p = GetParagraph(content, GetParams(GetFontSize(fontSize)), GetParams());
            body.AppendChild(p);
        }

        private static void AddTable(Body body, string fontSize = DEFAULT_FONT_SIZE)
        {
            Table table = GetTable();
            if (Patient.items.Count == 0)
            {
                AddPlain(body, "Пока что нет записей о пациентах...");
                return;
            }
            AddRow(table, fontSize, "ФИО", "Дата рождения", "Пол", "Кол-во приемов");
            Patient.items.ForEach(patient =>
            {
                int appointments = 0;
                Appointment.items.ForEach(appointment =>
                {
                    if (appointment.PatientID == patient.ID)
                    {
                        appointments++;
                    }
                });
                AddRow(table, fontSize, patient.Name, patient.Birth, patient.Sex, appointments.ToString());
            });
            body.AppendChild(table);
        }

        private static Table GetTable()
        {
            Table table = new Table();

            TableProperties tblProp = new TableProperties(
                new TableWidth() { Width = "100%", Type = TableWidthUnitValues.Pct },
                new TableBorders(
                    new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                    new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                    new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                    new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                    new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                    new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 }
                )
            );

            table.AppendChild(tblProp);

            return table;
        }

        private static void AddRow(Table table, string fontSize = DEFAULT_FONT_SIZE, params string[] cellTexts)
        {
            TableRow row = new TableRow();
            foreach (string cellText in cellTexts)
            {
                AddCell(row, cellText, fontSize);
            }
            table.Append(row);
        }

        private static void AddCell(TableRow row, string text, string fontSize = DEFAULT_FONT_SIZE)
        {
            TableCell tc = new TableCell();
            Paragraph p = GetParagraph(text, GetParams(GetFontSize(fontSize)), GetParams(GetCentered()));
            tc.Append(p);
            row.Append(tc);
        }
    }
}
