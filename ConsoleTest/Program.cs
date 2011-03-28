﻿using System;
using System.Drawing;
using Word.Api.Interfaces;
using Word.W2004;
using Word.W2004.Elements;
using Word.W2004.Elements.TableElements;
using Word.W2004.Style;
using Font = Word.W2004.Style.Font;
using Image = Word.W2004.Elements.Image;

namespace ConsoleTest
{
    class Program
    {
        private static void Do()
        {
            IDocument doc = new Document2004();

            doc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("This is Strike text").WithStyle().Strike().Create()));
            doc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("This is Caps text").WithStyle().Caps().Create()));
            doc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("This is DoubleStrike text").WithStyle().DoubleStrike().Create()));
            doc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("This is Emboss text").WithStyle().Emboss().Create()));
            doc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("This is Imprint text").WithStyle().Imprint().Create()));
            doc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("This is Outline text").WithStyle().Outline().Create()));
            doc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("This is Shadow text").WithStyle().Shadow().Create()));
            doc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("This is SmallCaps text").WithStyle().SmallCaps().Create()));
            doc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("Text").Create(),
                ParagraphPiece.With("This is Subscript text").WithStyle().Subscript().Create()));
            doc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("Text").Create(),
                                            ParagraphPiece.With("This is Superscript text").WithStyle().Superscript().Create()));
            doc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("This is Vanish text").WithStyle().Vanish().Create()));

            doc.Save(@"C:\styles.doc");
        }

        static void Main(string[] args)
        {
            Do();
            IDocument myDoc = new Document2004();

            myDoc.AddEle(BreakLine.SetTimes(1).Create()); // this is one breakline

            //Headings
            myDoc.AddEle(Heading2.With("===== Headings ======").Create());
            myDoc.AddEle(
                Paragraph.With(
                    "This doc has been generated by Sharp2Word.")
                    .Create());
            myDoc.AddEle(BreakLine.SetTimes(1).Create());

            myDoc.AddEle(Paragraph
                             .With("I will try to use a little bit of everything in the API Sharp2word. " +
                                   "I realised that is very dificult to keep the doucmentation updated " +
                                   "so this is where I will demostrate how to do some cool things with Sharp2Word!")
                             .Create());


            myDoc.AddEle(Heading1.With("Heading01 without styling").Create());
            myDoc.AddEle(Heading2.With("Heading02 with styling").WithStyle()
                             .Align(Align.CENTER).Italic().Create());
            myDoc.AddEle(Heading3.With("Heading03").WithStyle().Bold()
                             .Align(Align.RIGHT).Create());

            //Paragraph and ParagrapPiece
            myDoc.AddEle(Heading2.With("===== Paragraph and ParagrapPiece ======").Create());
            myDoc.AddEle(Paragraph.With("I am a very simple paragraph.").Create());

            myDoc.AddEle(BreakLine.SetTimes(1).Create());
            ParagraphPiece myParPiece01 =
                ParagraphPiece.With(
                    "If you use the class 'Paragraph', you will have limited style. Maybe only paragraph aligment.");
            ParagraphPiece myParPiece02 =
                ParagraphPiece.With("In order to use more advanced style, you have to use ParagraphPiece");
            ParagraphPiece myParPiece03 =
                ParagraphPiece.With(
                    "One example of this is when you want to make ONLY one word BOLD or ITALIC. the way to to this is create many pieces, format them separetely and put all together in a Paragraph object. Example:");

            myDoc.AddEle(Paragraph.WithPieces(myParPiece01, myParPiece02, myParPiece03).Create());

            
            ParagraphPiece myParPieceJava = ParagraphPiece.With("I like C# and ").WithStyle().Font(Font.COURIER).Create();
            ParagraphPiece myParPieceRuby = ParagraphPiece.With("Ruby!!! ").WithStyle().Bold().Italic().Create();
            ParagraphPiece myParPieceAgile =
                ParagraphPiece.With("I actually love C#, TDD, patterns... ").WithStyle().
                    TextColor("008000").Create();

            myDoc.AddEle(Paragraph.WithPieces(myParPieceJava, myParPieceRuby, myParPieceAgile).Create());

            //font size
            myDoc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("No size").Create(),
                                              ParagraphPiece.With("I am size 50.").WithStyle().FontSize(50).TextColor(Color.Cyan).Create()));


            //Document Header and Footer
            myDoc.AddEle(BreakLine.SetTimes(2).Create());
            myDoc.AddEle(Heading2.With("===== Document Header and Footer ======").Create());
            myDoc.AddEle(Paragraph.With("By default everything is added to the Body when you do 'myDoc.AddEle(...)'." +
                                        " But you can add elements to the Header and/or Footer. Other cool thing is show page number or not.")
                             .Create());

            myDoc.AddEle(BreakLine.SetTimes(2).Create());
            myDoc.AddEle(
                Paragraph.With(
                    "Page number is displayed by default but you can disable: 'myDoc.getFooter().showPageNumber(false)' ")
                    .Create());

            myDoc.AddEle(BreakLine.SetTimes(2).Create());
            myDoc.AddEle(
                Paragraph.With(
                    "you can also hide Header and Footer in the first Page. This is useful for when you have a cover page.: 'myDoc.getHeader().SetHideHeaderAndFooterFirstPage(true)' ")
                    .Create());

            myDoc.Header.AddEle(
                Paragraph.WithPieces(ParagraphPiece.With("I am in the"),
                                     ParagraphPiece.With(" Header ").WithStyle().Bold().Create(),
                                     ParagraphPiece.With("of all pages")).Create());

            myDoc.Footer.AddEle(Paragraph.With("I am in the Footer of all pages").Create());


            //Images
            myDoc.AddEle(BreakLine.SetTimes(1).Create());
            myDoc.AddEle(Heading2.With("===== Images ======").Create());
            myDoc.AddEle(
                Paragraph.With(
                    "Images can be created from diferent locations. It can be from your local machine, from web URL or classpath.")
                    .Create());

            myDoc.AddEle(Paragraph.With("This one is coming from WEB, google web site: ").Create());
            myDoc.AddEle(Image.From_WEB_URL("http://www.google.com/images/logos/ps_logo2.png"));

            myDoc.AddEle(BreakLine.SetTimes(2).Create());
            myDoc.AddEle(Paragraph.With("You can change the image dimensions:.").Create());
            myDoc.AddEle(
                Image.From_WEB_URL("http://www.google.com/images/logos/ps_logo2.png").SetHeight(40).SetWidth(80).
                    Create());


            myDoc.AddEle(BreakLine.SetTimes(2).Create());
            myDoc.AddEle(
                Paragraph.With(
                    "You can always be creative mixing up images inside other IElements. Eg.: Paragraphs, Tables, etc.")
                    .Create());

            /*myDoc.addEle(
                            new Paragraph("This document inside the paragraph, coming from '/src/test/resources/dtpick.gif': "
                                            + Image.from_FULL_LOCAL_PATHL(Utils.getAppRoot() + "/src/test/resources/dtpick.gif").getContent()));
            */
            myDoc.AddEle(BreakLine.SetTimes(1).Create());


            //Table
            myDoc.AddEle(Heading2.With("===== Table ======").Create());
            myDoc.AddEle(
                Paragraph.With("Table os soccer playerd and their number of gols - the best of the best of all times:").
                    Create());
            myDoc.AddEle(BreakLine.SetTimes(1).Create());

            Table tbl = new Table();
            tbl.AddTableEle(TableEle.TH, "Name", "Number of gols", "Country");

            tbl.AddTableEle(TableEle.TD, "Arthur Friedenreich", "1329", "Brazil");
            tbl.AddTableEle(TableEle.TD, "Pele", "1281", "Brazil");
            tbl.AddTableEle(TableEle.TD, "Romario", "1002", "Brazil");
            tbl.AddTableEle(TableEle.TD, "Tulio Maravilha", "956", "Brazil");
            tbl.AddTableEle(TableEle.TD, "Zico", "815", "Brazil");
            tbl.AddTableEle(TableEle.TD, "Roberto Dinamite", "748", "Brazil");
            tbl.AddTableEle(TableEle.TD, "Di Stéfano", "715", "Argentina");
            tbl.AddTableEle(TableEle.TD, "Puskas", "689", "Hungary");
            tbl.AddTableEle(TableEle.TD, "Flávio", "591", "Brazil");
            tbl.AddTableEle(TableEle.TD, "James McGory", "550", "Scotland");
            tbl.AddTableEle(TableEle.TD, "Leonardo Correa", "299", "Brazil/Australia");

            tbl.AddTableEle(TableEle.TF, "Total", "1,100,000.00", " ");

            myDoc.AddEle(tbl);

            myDoc.AddEle(BreakLine.SetTimes(1).Create());

            myDoc.AddEle(
                Paragraph.WithPieces(
                    ParagraphPiece.With("* Zico was mid-fieldfer and managed to score all those fucking goals!").
                        WithStyle().Italic().Create()).Create());
            myDoc.AddEle(
                Paragraph.WithPieces(
                    ParagraphPiece.With(
                        "* Leonardo Correa's goals (me) include futsal, soccer, friendly games, training games, so on... (but not playstation)")
                        .WithStyle().Italic().Create()).Create());


            //PageBreaks
            myDoc.AddEle(Heading2.With("===== PageBreak ======").Create());
            myDoc.AddEle(Paragraph.With("There is a PAGE BREAK after this line:").Create());
            myDoc.AddEle(PageBreak.Create());
            myDoc.AddEle(Paragraph.With("There is a PAGE BREAK before this line:").Create());


            //subscript
            Paragraph subscript = Paragraph.WithPieces(ParagraphPiece.With("Text without subscript").Create(),
                                                 ParagraphPiece.With("Text with subscript").WithStyle().Subscript().Create());
            myDoc.AddEle(subscript);

            //superscript
            Paragraph superscript = Paragraph.WithPieces(ParagraphPiece.With("Text without superscript").Create(),
                                                 ParagraphPiece.With("Text with superscript").WithStyle().Superscript().Create());
            myDoc.AddEle(superscript);

            //Strikethrough
            myDoc.AddEle(Paragraph.WithPieces(ParagraphPiece.With("This is Strikethrough text").WithStyle().Strike().Create()));
            //myDoc.AddEle(Paragraph.With("This is Strikethrough text".Create());


            myDoc.Save(@"c:\mytest.doc");
        }

    }
}