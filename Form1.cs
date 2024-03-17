using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tesseract;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnPaste.Click += btnPaste_Click;
            btnCopy.Click += btnCopy_Click; // Add click event handler for the Copy button
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            // Try to get an image from clipboard
            if (Clipboard.ContainsImage())
            {
                Image clipboardImage = Clipboard.GetImage();
                pictureBox.Image = clipboardImage;

                // Preprocess image for better OCR accuracy
                Bitmap processedImage = PreprocessImage(new Bitmap(clipboardImage));

                // Save processed image to a file
                processedImage.Save("./temp.bmp");

                // Perform OCR on the image
                string recognizedPlate = RecognizeLicensePlate(processedImage);
                if (!string.IsNullOrEmpty(recognizedPlate))
                {
                    textBox.Text = $"CLEAR PLATE {recognizedPlate}";
                }
                else
                {
                    MessageBox.Show("No valid license plate found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Clipboard does not contain an image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // Check if the text box contains any text
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                // Copy the text from the text box to the clipboard
                Clipboard.SetText(textBox.Text);
            }
        }

        private Bitmap PreprocessImage(Bitmap originalImage)
        {
            // Implement image preprocessing techniques here
            // Example: Convert to grayscale and apply filters
            // Return the preprocessed image
            return originalImage;
        }

        private string RecognizeLicensePlate(Bitmap processedImage)
        {
            try
            {
                using (var engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default))
                {
                    using (var pix = Pix.LoadFromFile("./temp.bmp"))
                    {
                        using (var page = engine.Process(pix))
                        {
                            string recognizedText = page.GetText().Trim();

                            // Extract potential license plate candidates
                            Regex regex = new Regex(@"\b[A-Z0-9]{3}-[A-Z0-9]{4}\b");
                            MatchCollection matches = regex.Matches(recognizedText);

                            foreach (Match match in matches)
                            {
                                string plateCandidate = match.Value;
                                string correctedPlate = CorrectLicensePlate(plateCandidate);

                                // Check if the corrected plate follows the format of 0A0-A0A0
                                if (correctedPlate != null)
                                {
                                    return correctedPlate;
                                }
                            }
                        }
                    }
                }
            }
            catch (TesseractException ex)
            {
                MessageBox.Show($"Tesseract Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        private string CorrectLicensePlate(string plate)
        {
            // Define a dictionary to store commonly misinterpreted characters
            Dictionary<char, char> correctionMap = new Dictionary<char, char>
            {
                {'1', 'I'},
                {'0', 'O'},
                {'B', '8'},
                {'S', '5'},
                // Add more corrections as needed
            };

            // Apply corrections to each character
            for (int i = 0; i < plate.Length; i++)
            {
                char currentChar = plate[i];

                // Check if the current character needs correction
                if (correctionMap.ContainsKey(currentChar))
                {
                    plate = plate.Substring(0, i) + correctionMap[currentChar] + plate.Substring(i + 1);
                }
            }

            // Ensure the plate follows the format of 0A0-A0A0
            if (Regex.IsMatch(plate, @"^[0-9][A-Z][0-9]-[A-Z][0-9][A-Z][0-9]$"))
            {
                return plate;
            }
            else
            {
                return null;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
