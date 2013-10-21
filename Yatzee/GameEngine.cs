using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Yatzee.Scoring;

namespace Yatzee
{
    /// <summary>
    /// Primary game engine for playing Yatzee
    /// </summary>
    internal class GameEngine
    {
        /// <summary>
        /// Play the game
        /// </summary>
        public void Play()
        {
            InitializeGame();

            bool quit = false;
            bool play = true;

            while (!quit)
            {
                if (play)
                {
                    Console.Write("Press <enter> to roll or <esc> to quit: ");
                    play = false;
                }

                // Get the next key press
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        play = true;
                        PlayYatzee();
                        break;
                    case ConsoleKey.Escape:
                        quit = true;
                        break;
                }
            }
        }

        /// <summary>
        /// The dice used for the game
        /// </summary>
        protected Dice Dice
        {
            get
            {
                return _dice;
            }
        }
        private Dice _dice = new Dice();

        /// <summary>
        /// Possilbe rules used for scoring
        /// </summary>
        protected List<IScore> ScoringRules
        {
            get
            {
                return _scoringRules;
            }
        }
        private List<IScore> _scoringRules;

        #region Private Functions

        /// <summary>
        /// Initialize the game
        /// </summary>
        private void InitializeGame()
        {
            // Add the game Scoring Rules
            _scoringRules = new List<IScore>() 
            { 
                new ThreeOfAKind(), 
                new FourOfAKind(), 
                new YatzeeScore(), 
                new FullHouse(),
                new SmallStraight(),
                new LargeStraight(),
                new Chance()
            };
        }

        /// <summary>
        /// Roll the dice and calculate scores
        /// </summary>
        private void PlayYatzee()
        {
            List<int> reRoll = null;

            // Allow up to three rolls
            for (int i = 1; i < 4; i++)
            {
                // Check if the user wants to change any dice
                if (i > 1)
                {
                    reRoll = GetWhichDiceToReRoll();
                    // Check if the user decided not to re-roll
                    if (reRoll.Count == 0)
                    {
                        break;
                    }
                }

                // Roll the Dice
                Dice.Roll(reRoll);
                // Display the role results
                Console.WriteLine("Roll {0}:", helpers.IntToString(i));
                Dice.ForEach(d => Console.Write("\t{0}", d));
                Console.WriteLine();
   
                // Calculate all scores
                ScoringRules.ForEach(r => r.CalculateScore(Dice));

                // Display the scores from best to worst
                foreach (IScore score in ScoringRules.Where(s => s.Points > 0).OrderByDescending(o => o.Points))
                {
                    Console.WriteLine("{0}: {1}", score.Name, score.Points);
                }
            }
            Console.WriteLine("-----------------------------------------------------");
        }

        /// <summary>
        /// Get a list of which dice to re-roll
        /// </summary>
        private List<int> GetWhichDiceToReRoll()
        {
            Console.Write("Which dice would you like to re-roll (12345)? <enter> for none: ");
            Regex match = new Regex("[^0-9]*");
            string input = match.Replace(Console.ReadLine(), string.Empty);

            var results = new List<int>();
            // Go through each space delimited input
            for (int i = 0; i < input.Length; i++)
            {
                results.Add(int.Parse(input[i].ToString()));
            }

            // Done
            return results;
        }

        #endregion Private Funcitons

    }
}
