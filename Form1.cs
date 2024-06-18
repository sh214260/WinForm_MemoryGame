using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyFirstGui
{
    public partial class Form1 : Form
    {
        private Card[] cards;
        private Card selectedCard1;
        private Card selectedCard2;
        private Image backgroundImage;
        PictureBox pictureBox1 = new PictureBox();
        PictureBox pictureBox2 = new PictureBox();
        const int amountOfCard= 6;
        public Form1()
        {
            InitializeComponent();
            backgroundImage = Properties.Resources.background;
            cards = new Card[amountOfCard];
            SetupCards();
        }
        private void SetupCards()
        {
            Image[] images = new Image[]
            {
            Properties.Resources.apple,
            Properties.Resources.watermeloon,
            Properties.Resources.banana,
            };
            int j = 0;
            for (int i = 0; i < images.Length; i++)
            {
                cards[j] = new Card(images[i]);
                cards[j + 1] = new Card(images[i]);
                j += 2;
            }

            ShuffleCards(cards);

            for (int i = 0; i < cards.Length; i++)
            {
                PictureBox pictureBox = CreatePictureBox(i);
                this.Controls.Add(pictureBox);
            }
        }
        private PictureBox CreatePictureBox(int index)
        {
            PictureBox pictureBox = new PictureBox();
            int row = index / 3;
            int col = index % 3;
            pictureBox.Location = new Point(100 + col * 110, 50 + row * 110);
            pictureBox.Size = new Size(100, 100);
            pictureBox.Image = backgroundImage;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Click += pictureBox_Click;
            return pictureBox;
        }

        //Shuffle the cards by replacing 2 cards randomly
        private void ShuffleCards(Card[] cards)
        {
            Random random = new Random();
            for (int i = cards.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        //A function that is activated when a card is clicked and checks if the cards are similar and acts accordingly
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            int index = pictureBox.TabIndex;
            Card card = cards[index];
            if (!card.IsMatched)
            {
                card.Flip();
                pictureBox.Image = card.Image;

                if (selectedCard1 == null)
                {
                    pictureBox1 = pictureBox;
                    selectedCard1 = card;
                }
                else if (selectedCard2 == null)
                {
                    pictureBox2 = pictureBox;
                    selectedCard2 = card;

                    if (selectedCard1.Image == selectedCard2.Image)
                    {
                        MessageBox.Show("הצלחת!");
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("לא נכון!");
                        pictureBox1.Image = backgroundImage;
                        pictureBox2.Image = backgroundImage;
                        selectedCard1.Flip();
                        selectedCard2.Flip();
                    }
                    selectedCard1 = null;
                    selectedCard2 = null;
                }
            }
        }
    }

}
