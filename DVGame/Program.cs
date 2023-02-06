class Card
{
    public string Name;
    public int Value;
    public string Suit;
    //public override string ToString() { return string.Format("{0} of {1}", Name, Suit); }
}
class PlayerHand
{
    public string PlayerName;
    public string Name;
    public int Value;
    public string Suit;
}

class SuitScore
{
    public string PlayerName;
    public int Score;

}
class DeckOfCards
{
    static void Main(string[] args)
    {
        string[] Players = { "Player1", "Player2", "Player3", "Player4", "Player5", "Player6", "Player7" };

        #region
        List<Card> DeckOfCards = new List<Card>()
                {
                    new Card{Name="ace", Value=11, Suit="AH"},
                    new Card{Name="two",Value=2,Suit="2H"},
                    new Card{Name="three",Value=3,Suit="3H"},
                    new Card{Name="four",Value=4,Suit="4H"},
                    new Card{Name="five", Value=5, Suit="5H"},
                    new Card{Name="six",Value=6,Suit="6H"},
                    new Card{Name="seven",Value=7,Suit="7H"},
                    new Card{Name="eight",Value=8,Suit="8H"},
                    new Card{Name="nine", Value=9, Suit="9H"},
                    new Card{Name="ten",Value=10,Suit="10H"},
                    new Card{Name="jack",Value=11,Suit="JH"},
                    new Card{Name="queen",Value=12,Suit="QH"},
                    new Card{Name="king", Value=13, Suit="KH"},
                    new Card{Name="ace", Value=11, Suit="AS"},
                    new Card{Name="two",Value=2,Suit="2S"},
                    new Card{Name="three",Value=3,Suit="3S"},
                    new Card{Name="four",Value=4,Suit="4S"},
                    new Card{Name="five", Value=5, Suit="5S"},
                    new Card{Name="six",Value=6,Suit="6S"},
                    new Card{Name="seven",Value=7,Suit="7S"},
                    new Card{Name="eight",Value=8,Suit="8S"},
                    new Card{Name="nine", Value=9, Suit="9S"},
                    new Card{Name="ten",Value=10,Suit="10S"},
                    new Card{Name="jack",Value=11,Suit="JS"},
                    new Card{Name="queen",Value=12,Suit="QS"},
                    new Card{Name="king", Value=13, Suit="KS"},
                    new Card{Name="ace", Value=11, Suit="AD"},
                    new Card{Name="two",Value=2,Suit="2D"},
                    new Card{Name="three",Value=3,Suit="3D"},
                    new Card{Name="four",Value=4,Suit="4D"},
                    new Card{Name="five", Value=5, Suit="5D"},
                    new Card{Name="six",Value=6,Suit="6D"},
                    new Card{Name="seven",Value=7,Suit="7D"},
                    new Card{Name="eight",Value=8,Suit="9D"},
                    new Card{Name="nine", Value=9, Suit="9D"},
                    new Card{Name="ten",Value=10,Suit="10D"},
                    new Card{Name="jack",Value=11,Suit="JD"},
                    new Card{Name="queen",Value=12,Suit="QD"},
                    new Card{Name="king", Value=13, Suit="KD"},
                    new Card{Name="ace", Value=11, Suit="AC"},
                    new Card{Name="two",Value=2,Suit="2C"},
                    new Card{Name="three",Value=3,Suit="3C"},
                    new Card{Name="four",Value=4,Suit="4C"},
                    new Card{Name="five", Value=5, Suit="5C"},
                    new Card{Name="six",Value=6,Suit="6C"},
                    new Card{Name="seven",Value=7,Suit="7C"},
                    new Card{Name="eight",Value=8,Suit="8C"},
                    new Card{Name="Nine", Value=9, Suit="9C"},
                    new Card{Name="ten",Value=10,Suit="10C"},
                    new Card{Name="jack",Value=11,Suit="JC"},
                    new Card{Name="queen",Value=12,Suit="QC"},
                    new Card{Name="king", Value=13, Suit="KC"}

                };
        #endregion


        //Deal cards to players
        Random random = new Random();
        List<PlayerHand> player = new List<PlayerHand>();

        var deckOne = DeckOfCards;
        var deckTwo = DeckOfCards;
        player.Clear();
        int numberOfCards = 0;
        for (int p = 0; p < Players.Length; p++)
        {
            numberOfCards = 0;
            for (int hc = 0; numberOfCards < 5; hc++)
            {

                for (int d = 0; d < deckOne.Count; d++)
                {
                    int r1;
                    r1 = random.Next(0, deckOne.Count);
                    player.Add(new PlayerHand { PlayerName = Players[p], Name = deckOne[r1].Name, Suit = deckOne[r1].Suit, Value = deckOne[r1].Value });
                    numberOfCards++;
                    int index = deckOne.IndexOf(deckOne[r1]);
                    deckOne.RemoveAt(index);
                    break;
                }
                if (numberOfCards == 5)
                {
                    break;
                }
                else
                {
                    for (int dt = 0; dt < deckTwo.Count; dt++)
                    {
                        int r1;
                        r1 = random.Next(0, deckTwo.Count);
                        player.Add(new PlayerHand { PlayerName = Players[p], Name = deckTwo[r1].Name, Suit = deckTwo[r1].Suit, Value = deckTwo[r1].Value });
                        numberOfCards++;
                        int index = deckTwo.IndexOf(deckTwo[r1]);
                        deckTwo.RemoveAt(index);
                        break;
                    }
                }

            }


        }

        //Display each player's cards
        string CurrentPlayer = "";
        var text = "";

        for (int p = 0; p < Players.Length; p++)
        {
            text = "";
            CurrentPlayer = Players[p];
            var playerCards = player.FindAll(x => x.PlayerName == CurrentPlayer).ToArray();
            foreach (var r in playerCards)
            {
                text += r.Suit + ",";


            }
            text = text.Remove(text.Length - 1, 1);
            Console.WriteLine(CurrentPlayer + ": " + text.TrimEnd());
        }


        //Calculate the score
        List<SuitScore> scores = new List<SuitScore>();
        int score = 0;
        scores.Clear();
        for (int p = 0; p < Players.Length; p++)
        {
            score = 0;

            CurrentPlayer = Players[p];
            var playerCards = player.FindAll(x => x.PlayerName == CurrentPlayer).ToArray();
            foreach (var r in playerCards)
            {
                score += r.Value;
            }
            scores.Add(new SuitScore { PlayerName = Players[p], Score = score });


        }

        //Display player's score
        string equalCardScorePlayers = "";
        List<SuitScore> scoreAfterSuitValue = new List<SuitScore>();
        List<SuitScore> scoreDisplay = new List<SuitScore>();
        bool tie = false;

        var highestScore = scores.Max(x => x.Score);
        var firstTie = scores.FindAll(x => x.Score == highestScore);
        if (firstTie.Count > 1)
        {
            foreach (var cl in firstTie)
            {
                var finalTieScore = player.FindAll(x => x.PlayerName == cl.PlayerName).ToArray();
                if (finalTieScore != null)
                {
                    tie = true;
                    foreach (var f in finalTieScore)
                    {
                        if (f.Suit.Contains("H"))
                        {
                            cl.Score = cl.Score + 1;
                        }
                        else if (f.Suit.Contains("S"))
                        {
                            cl.Score = cl.Score + 2;
                        }
                        else if (f.Suit.Contains("C"))
                        {
                            cl.Score = cl.Score + 3;
                        }
                        else
                        {
                            cl.Score = cl.Score + 4;
                        }
                    }
                    scoreAfterSuitValue.Add(new SuitScore { PlayerName = cl.PlayerName, Score = cl.Score });

                }

            }

        }
        else
        {
            foreach (var sd in scores.Distinct().OrderByDescending(x => x.Score))
            {
                Console.WriteLine(sd.PlayerName + ": " + sd.Score);
            }
        }

        

        for (int s = 0; s < scoreAfterSuitValue.Count; s++)
        {
            highestScore = scoreAfterSuitValue.Max(x => x.Score);
            var secondTie = scoreAfterSuitValue.FindAll(x => x.Score == highestScore);
            if (secondTie.Count > 1)
            {
                foreach (var st in secondTie)
                {
                    if (!equalCardScorePlayers.Contains(st.PlayerName))
                    {
                        equalCardScorePlayers += st.PlayerName + ",";
                    }

                }
            }
            else if (tie == true)
            {
                var checkIfExist = scores.Find(x => x.PlayerName == scoreAfterSuitValue[s].PlayerName);
                if (checkIfExist == null)
                {
                    int indexOf = scoreAfterSuitValue.IndexOf(scoreAfterSuitValue[s]);
                    Console.WriteLine(scoreAfterSuitValue[s].PlayerName + ": " + scoreAfterSuitValue[s].Score);
                    scoreAfterSuitValue.RemoveAt(indexOf);
                }

            }

        }
        if (!String.IsNullOrEmpty(equalCardScorePlayers))
        {
            Console.WriteLine(equalCardScorePlayers.Remove(equalCardScorePlayers.Length - 1, 1) + ": " + score);
        }


    }



}
