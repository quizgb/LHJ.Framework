using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LHJ.DBViewer
{
    //
    // Class RichDDLBox()
    // -------------------------------------------------------------------
    // This class represents a RichTextBox that show ddl and sql commands
    // of Oracle syntax. It inherits from the standart RichTextBox class
    // -------------------------------------------------------------------
    // Guy Haim 26/01/08
    //
    public class clsRichDDLBox : RichTextBox
    {
        // Setting default Colors & Fonts for the the different types of strings
        private Color clrDefault = Color.Black;
        private Font fntDefault = new Font("Courier New", 12, FontStyle.Regular);
        private Color clrKeyword = Color.Blue;
        private Font fntKeyword = new Font("Courier New", 12, FontStyle.Bold);
        private Color clrComment = Color.Green;
        private Font fntComment = new Font("Courier New", 12, FontStyle.Italic);
        private Color clrBackError = Color.Yellow;


        private String[] keywords = {"ACCESS",  "ELSE", "MODIFY",   "START", "REPLACE", "FUNCTION", "DECLARE",
                                        "ADD",  "EXCLUSIVE",    "NOAUDIT",  "SELECT", "PROCEDURE",
                                        "ALL",  "EXISTS",   "NOCOMPRESS",   "SESSION", "PACKAGE",
                                        "ALTER",    "FILE", "NOT",  "SET", "BODY",
                                        "AND",  "FLOAT",    "NOTFOUND", "SHARE", "BEGIN",
                                        "ANY",  "FOR",  "NOWAIT",   "SIZE", "END",
                                        "ARRAYLEN", "FROM", "NULL", "SMALLINT",
                                        "AS",   "GRANT",    "NUMBER",   "SQLBUF",
                                        "ASC",  "GROUP",    "OF",   "SUCCESSFUL",
                                        "AUDIT",    "HAVING",   "OFFLINE",  "SYNONYM",
                                        "BETWEEN",  "IDENTIFIED",   "ON",   "SYSDATE",
                                        "BY",   "IMMEDIATE",    "ONLINE",   "TABLE",
                                        "CHAR", "IN",   "OPTION",   "THEN",
                                        "CHECK",    "INCREMENT",    "OR",   "TO",
                                        "CLUSTER",  "INDEX",    "ORDER",    "TRIGGER",
                                        "COLUMN",   "INITIAL",  "PCTFREE",  "UID",
                                        "COMMENT",  "INSERT",   "PRIOR",    "UNION",
                                        "COMPRESS", "INTEGER",  "PRIVILEGES",   "UNIQUE",
                                        "CONNECT",  "INTERSECT",    "PUBLIC",   "UPDATE",
                                        "CREATE",   "INTO", "RAW",  "USER",
                                        "CURRENT",  "IS",   "RENAME",   "VALIDATE",
                                        "DATE","DATABASE",  "LEVEL", "LINK",    "RESOURCE", "VALUES",
                                        "DECIMAL",  "LIKE", "REVOKE",   "VARCHAR",
                                        "DEFAULT",  "LOCK", "ROW",  "VARCHAR2",
                                        "DELETE",   "LONG", "ROWID",    "VIEW",
                                        "DESC", "MAXEXTENTS",   "ROWLABEL", "WHENEVER",
                                        "DISTINCT", "MINUS",    "ROWNUM",   "WHERE",
                                        "DROP", "MODE", "ROWS", "SHARED",   "WITH"};

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.AcceptsTab = true;

            // Setting default color and font of the text (only if there text is no already)
            if (this.Text != null)
            {
                if (this.Text.Equals(""))
                {
                    this.ForeColor = clrDefault;
                    this.Font = fntDefault;
                }
            }
        }

        // public void SetDefaultColor(Color defColor)
        // Sets the color for default string
        public void SetDefaultColor(Color clr)
        {
            clrDefault = clr;
        }

        // public void SetKeywordColor(Color keywordColor)
        // Sets the color for keyword string
        public void SetKeywordColor(Color clr)
        {
            clrKeyword = clr;
        }

        // public void SetDefaultColor(Color defColor)
        // Sets the color for comment string
        public void SetCommentColor(Color clr)
        {
            clrComment = clr;
        }

        // Get default Color
        public Color GetDefaultColor()
        {
            return clrDefault;
        }

        // Get keyword Color
        public Color GetKeywordColor()
        {
            return clrKeyword;
        }

        // Get Comment Color
        public Color GetCommentColor()
        {
            return clrComment;
        }

        //
        // public void ParseDDL(String inputLanguage)
        // ----------------------------------------------------------
        // this method parses an input string - colors it according to given keywords,
        // and comment of SQL syntax . It also and adding it to a RichDDLBox text
        // ------------------------------------------------------------------
        // Guy Haim 26/01/08
        //
        public void ParseDDL(String inputLanguage)
        {
            bool IsInComment = false;
            int currLineNo = 0;

            Regex rLine = new Regex("\\n");
            Regex rToken = new Regex("([ \\t{}():;])");

            // Getting the lines list of the input string
            String[] arrInputlines = rLine.Split(inputLanguage);
            int intInputLinesNumber = arrInputlines.Length;

            // For each line
            foreach (string line in arrInputlines)
            {
                currLineNo++;
                // Getting the token list of the current line
                String[] tokens = rToken.Split(line);

                foreach (string token in tokens)
                {
                    if (IsInComment)
                    {
                        // Set the tokens color and font to be as of comment.
                        this.SelectionColor = clrComment;
                        this.SelectionFont = fntComment;
                    }
                    else
                    {
                        // Set the tokens default color and font.
                        this.SelectionColor = clrDefault;
                        this.SelectionFont = fntDefault;
                    }

                    // Check for begin of commant
                    if (token.Equals("/*") || token.StartsWith("/*"))
                    {
                        IsInComment = true;
                        this.SelectionColor = clrComment;
                        this.SelectionFont = fntComment;
                    }

                    // Check for a regular comment
                    if ((token.Equals("--") || token.StartsWith("--")) && !IsInComment)
                    {
                        // Find the start of the comment and then extract the whole comment.
                        int index = line.IndexOf("--");
                        string comment = line.Substring(index, line.Length - index);
                        this.SelectionColor = clrComment;
                        this.SelectionFont = fntComment;
                        this.SelectedText = comment;
                        break;
                    }

                    // Check whether the token is a keyword if not in a comment.
                    if (!IsInComment)
                    {
                        for (int i = 0; i < keywords.Length; i++)
                        {
                            if (keywords[i] == token.ToUpper())
                            {
                                // Apply alternative color and font to highlight keyword.
                                this.SelectionColor = clrKeyword;
                                this.SelectionFont = fntKeyword;
                                break;
                            }
                        }
                    }

                    // Check if end of comment
                    if (token.Equals("*/") || token.EndsWith("*/"))
                    {
                        IsInComment = false;
                    }

                    this.SelectedText = token;
                }

                // process to the next line only if its not the last line
                if (!(currLineNo.Equals(intInputLinesNumber)))
                {
                    this.SelectedText = "\n";
                }
            }

            // Set the tokens default color and font.
            this.SelectionColor = clrDefault;
            this.SelectionFont = fntDefault;
        }

        //
        // public void ArrangeSQL(String inputLanguage)
        // ----------------------------------------------------------
        // this method parses an input SQL string - 
        // and arranges it in a particular format.
        // ------------------------------------------------------------------
        // Guy Haim 26/01/08
        //
        public void ArrangeSQL()
        {
            String txtToParse = this.SelectedText.Trim();
            String txtNewArrangedSQL = "";
            bool bInSelect = false;
            bool bInFrom = false;
            bool bInWhere = false;

            // Do nothing if this is not a SELECT statement
            if (!txtToParse.StartsWith("SELECT", true, null))
            {
                return;
            }

            // Getting the token list of the current line
            Regex rToken = new Regex("([ \\t{}():;])");
            String[] tokens = rToken.Split(txtToParse);
            String[] columns;
            int nColCounter;

            foreach (string token in tokens)
            {
                if (!bInSelect)
                {
                    if (bInFrom) // We are in the part of "FROM ..."
                    {
                        if (token.ToUpper().Equals("WHERE"))
                        {
                            txtNewArrangedSQL += "\n" + token.ToUpper();
                            bInFrom = false;
                            bInWhere = true;
                        }
                        else
                        {
                            txtNewArrangedSQL += token;
                        }
                    }
                    else if (bInWhere) // We are in the part of "WHERE ..."
                    {
                        if (token.ToUpper().Equals("AND") || token.ToUpper().Equals("OR")) // 
                        {
                            txtNewArrangedSQL += "\n    " + token.ToUpper();
                        }
                        else if (token.ToUpper().Equals("GROUP"))
                        {
                            txtNewArrangedSQL += "\n" + token.ToUpper();
                            bInWhere = false;
                        }
                        else if (token.ToUpper().Equals("ORDER"))
                        {
                            txtNewArrangedSQL += "\n" + token.ToUpper();
                            bInWhere = false;
                        }
                        else
                        {
                            txtNewArrangedSQL += token;
                        }
                    }
                    else if (token.ToUpper() == "SELECT") // we enterd the command !
                    {
                        txtNewArrangedSQL += token.ToUpper();
                        bInSelect = true;
                    }
                    else // rest of SQL ...
                    {
                        if (token.ToUpper().Equals("GROUP") || token.ToUpper().Equals("ORDER"))
                        {
                            txtNewArrangedSQL += "\n" + token.ToUpper();
                        }
                        else if (token.ToUpper().Equals("GROUP"))
                        {
                            txtNewArrangedSQL += token.ToUpper();
                        }
                        else
                        {
                            txtNewArrangedSQL += token;
                        }
                    }

                }
                else // We are in the part of "SELECT ..."
                {
                    if (token.ToUpper().Equals("FROM"))
                    {
                        txtNewArrangedSQL += "\n" + token.ToUpper();
                        bInFrom = true;
                        bInSelect = false;
                    }
                    else if (token.EndsWith(","))
                    {
                        txtNewArrangedSQL += token + "\n      ";
                    }
                    else
                    {
                        // parsing the columns in the Select
                        columns = token.Split(',');
                        nColCounter = 0;
                        foreach (string col in columns)
                        {
                            ++nColCounter;
                            if (nColCounter.Equals(columns.Length)) // if this is last column in the select
                            {
                                txtNewArrangedSQL += col;
                            }
                            else
                            {
                                txtNewArrangedSQL += col + ",\n      ";
                            }
                        }

                    }
                }
            }

            this.SelectedText = txtNewArrangedSQL;
        }

        public void ColorErrorLine(int nLineNumber)
        {
            // clear all markings
            this.SelectAll();
            this.SelectionBackColor = Color.White;

            if (nLineNumber > 0)
            {
                int nLineStart = this.GetFirstCharIndexFromLine(nLineNumber);
                int nLineLength = this.Lines[nLineNumber].Length;

                this.Select(nLineStart, nLineLength);
                this.SelectionBackColor = clrBackError;
            }
        }

        public void ClearLine(int nLineNumber)
        {
            if (nLineNumber > 0)
            {
                int nLineStart = this.GetFirstCharIndexFromLine(nLineNumber);
                int nLineLength = this.Lines[nLineNumber].Length;

                this.Select(nLineStart, nLineLength);
                this.SelectionBackColor = Color.White;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // only in edit mode
            if (!this.ReadOnly)
            {
                base.OnKeyPress(e);

                string tmp = this.Text;

                // backup current selection in the text
                int selStart = this.SelectionStart;
                int selLength = this.SelectionLength;

                this.Text = "";
                this.ParseDDL(tmp);

                // restore the current selection in the text
                this.SelectionStart = selStart;
                this.SelectionLength = selLength;
            }
        }
    }
}
