using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static trUtils.tr2Utils;

namespace tr2editor
{


    public partial class Form1 : Form
    {

        public static string trName;

        public static byte[,] dataBlock;

        public static byte[,] pointerBlock;

        public static byte[] trFile;

        public static string[] txtData;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            closeFile(ids, entry, info);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void open_Click(object sender, EventArgs e)
        {
            // File dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select a tr2 file";
            openFileDialog1.DefaultExt = "tr2";
            openFileDialog1.Filter = "tr2 files (*.tr2)|*.tr2|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (trFile == null || trFile.GetLength(0) > 0)
                {
                    closeFile(ids, entry, info);
                }
                var fileName = openFileDialog1.FileName;
                trFile = File.ReadAllBytes(fileName);
                if (!checkTrFile(trFile))
                {
                    Array.Clear(trFile, 0, trFile.Length);
                    MessageBox.Show("Invalid tr2 file!");
                }
                else
                    parseFile(ids);
            }
        }

        public static void parseFile(ListBox ids)
        {
            // Parses the tr2 file
            updateFileName();
            pointerBlock = getPointerBlock(trFile);
            int[] sizeArr = new int[pointerBlock.GetLength(0)];
            for (int i = 0; i < sizeArr.Length; i++)
            {
                sizeArr[i] = getDataSize(i, pointerBlock);
            }

            dataBlock = new byte[pointerBlock.GetLength(0), sizeArr.Max()];
            for (int i = 0; i < pointerBlock.GetLength(0); i++)
            {
                int currDataSize = sizeArr[i];
                byte[] currData = getDataBlock(pointerBlock, trFile, currDataSize, i);
                for (int j = 0; j < currData.Length; j++)
                {
                    dataBlock[i, j] = currData[j];
                }
            }
            txtData = new string[dataBlock.GetLength(0)];
            for (int i = 0; i < dataBlock.GetLength(0); i++)
            {
                txtData[i] = getBlockData(dataBlock, i);
            }
            addItemsToList(dataBlock, ids);
        }

        public static void addItemsToList(byte[,] dataBlock, ListBox ids)
        {
            // Adds the entries to the list
            string[] nameArr = new string[dataBlock.GetLength(0)];
            for (int i = 0; i < nameArr.Length; i++)
            {
                nameArr[i] = getEntryName(dataBlock, i);
            }
            ids.Items.AddRange(nameArr);
        }
        public static void updateFileName()
        {
            // Sets the file name to the name that is specified in the tr2 file
            byte[] nameIdPart = getPart(trFile, 0x8, 0x1F, true);
            var str = System.Text.Encoding.Default.GetString(nameIdPart);
            trName = str;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void ids_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Selects an item and shows its text entry
            string curItem = ids.SelectedItem.ToString();
            int index = ids.FindString(curItem);
            entry.Text = txtData[index];
            info.Text = "Block name: " + getEntryName(dataBlock, index) + "\nData type: " + getDataType(dataBlock, index);
        }

        public static void closeFile(ListBox ids, TextBox entry, Label info)
        {
            // Closes the file and clears all of the variables
            trFile = null;
            txtData = null;
            trName = "";
            ids.Items.Clear();
            entry.Text = "";
            info.Text = "";
        }
    }
}
