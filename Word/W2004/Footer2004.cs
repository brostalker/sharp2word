using System.Text;
using Word.Api.Interfaces;

namespace Word.W2004
{
    public class Footer2004 : IFooter
    {
        private const string HEADER_TOP = "\n	<w:ftr w:type=\"odd\">";
        private const string HEADER_BOTTON = "\n	</w:ftr>";

        private const string PAGE_NUMBER =
            "\n                <wx:pBdrGroup> "
            + "\n                    <wx:apo> "
            + "\n                        <wx:jc wx:val=\"right\"/> "
            + "\n                    </wx:apo> "
            + "\n                    <w:p wsp:rsidR=\"00595002\" wsp:rsidRDefault=\"00595002\" wsp:rsidP=\"00165A2B\"> "
            + "\n                        <w:pPr> "
            + "\n                            <w:pStyle w:val=\"Footer\"/> "
            +
            "\n                            <w:framePr w:wrap=\"around\" w:vanchor=\"text\" w:hanchor=\"margin\" w:x-align=\"right\" w:y=\"1\"/> "
            + "\n                            <w:rPr> "
            + "\n                                <w:rStyle w:val=\"PageNumber\"/> "
            + "\n                            </w:rPr> "
            + "\n                        </w:pPr> "
            + "\n                        <w:r> "
            + "\n                            <w:rPr> "
            + "\n                                <w:rStyle w:val=\"PageNumber\"/> "
            + "\n                            </w:rPr> "
            + "\n                            <w:fldChar w:fldCharType=\"begin\"/> "
            + "\n                        </w:r> "
            + "\n                        <w:r> "
            + "\n                            <w:rPr> "
            + "\n                                <w:rStyle w:val=\"PageNumber\"/> "
            + "\n                            </w:rPr> "
            + "\n                            <w:instrText>PAGE  </w:instrText> "
            + "\n                        </w:r> "
            + "\n                        <w:r> "
            + "\n                            <w:rPr> "
            + "\n                                <w:rStyle w:val=\"PageNumber\"/> "
            + "\n                            </w:rPr> "
            + "\n                            <w:fldChar w:fldCharType=\"separate\"/> "
            + "\n                        </w:r> "
            + "\n                        <w:r> "
            + "\n                            <w:rPr> "
            + "\n                                <w:rStyle w:val=\"PageNumber\"/> "
            + "\n                                <w:noProof/> "
            + "\n                            </w:rPr> "
            + "\n                            <w:t>2</w:t> "
            + "\n                        </w:r> "
            + "\n                        <w:r> "
            + "\n                            <w:rPr> "
            + "\n                                <w:rStyle w:val=\"PageNumber\"/> "
            + "\n                            </w:rPr> "
            + "\n                            <w:fldChar w:fldCharType=\"end\"/> "
            + "\n                        </w:r> "
            + "\n                    </w:p> "
            + "\n                </wx:pBdrGroup> \n";

        private readonly StringBuilder _txt = new StringBuilder("");

        private bool _hasBeenCalledBefore;
        private bool _showPageNumber;

        #region Implementation of IElement

        /// <summary>
        ///   <p>This method returns the content (XML or HTML) of the Element and the content.</p>
        ///   <p>If you are using W2004, the return will be the XML required to generate the element.</p>
        /// 
        ///   <p>Important: Once you call this method, the Document value is cached an no elements can be added later.</p>
        ///   <example>
        ///     <p>This is the XML that generates a <code>BreakLine</code>:</p>
        ///     <code>
        ///       <w:p wsp:rsidR = '008979E8' wsp:rsidRDefault = '008979E8' />
        ///     </code>
        ///   </example>
        /// </summary>
        /// <value>This is the string value of the element ready to be appended/inserted in the Document.</value>
        public string Content
        {
            get
            {
                if ("".Equals(_txt.ToString()))
                {
                    return "";
                }
                if (_hasBeenCalledBefore)
                {
                    return _txt.ToString();
                }
                else
                {
                    _hasBeenCalledBefore = true;
                }

                _txt.Insert(0, HEADER_TOP);
                if (_showPageNumber)
                {
                    _txt.Append(PAGE_NUMBER);
                }
                _txt.Append(HEADER_BOTTON);

                return _txt.ToString();
            }
        }

        #endregion

        #region Implementation of IHasElement

        /// <summary>
        ///   The content of the Element will be evaluated inside the object.
        /// 
        ///   This is an alias to 'getBody().addEle'
        /// </summary>
        /// <param name = "e"></param>
        public void AddEle(IElement e)
        {
            this._txt.Append("\n" + e.Content);
        }

        /// <summary>
        ///   In order to give flexibility, string methods was added.
        ///   Imagine you need to add an element which hasn't been implemented, for example, <b>Graphs</b>.
        ///   You know how to generate the XML to generate a Graph because you figured it out by yourself.
        ///   In this case you could do this:
        ///   <code>
        ///     IDocument myDoc = new Document2004();
        ///     string myXml = myMethodToReturnXML(); //This method return the XML to generate my graph - you have to write this one
        ///     myDoc.getBody().addEle(new Paragraph("This is a my graph: " + myXml));
        ///   </code>
        ///   This is an alias to 'getBody().addEle'
        /// </summary>
        /// <param name = "str"></param>
        public void AddEle(string str)
        {
            this._txt.Append("\n" + str);
        }

        public void ShowPageNumber()
        {
            this._showPageNumber = true;
        }

        #endregion

        // if getContent has already been called, I cached the result for future invocations
    }
}