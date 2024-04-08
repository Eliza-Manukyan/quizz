using Microsoft.AspNetCore.Components;
using Quizzing.Models;

namespace Quizzing.Pages
{
    public class QuizCardBase : ComponentBase
    {
        public List<Question> Questions { get; set; } = new List<Question>();
        protected int questionIndex = 0;
        protected int score = 0;

        protected override Task OnInitializedAsync()
        {
            LoadQuestions();

            return base.OnInitializedAsync();
        }
        protected void TopicSelected(string topic)
        {
            Questions.Clear();
            switch (topic)
            {
                case "Math":
                    LoadThemeMathQuestions();
                    break;
                case "Physics":
                    LoadThemePhysicsQuestions();
                    break;
                case "History":
                    LoadThemeHystoryQuestions();
                    break;
                case "Literature":
                    LoadThemeLogicQuestions();
                    break;
                default:
                    // Handle invalid selection
                    break;
            }
        }

        protected void LoadQuestions()
        {
            Questions.Clear();
            // Add a default question for topic selection
            Questions.Add(new Question
            {
                QuestionTitle = "Choose a topic",
                Options = new List<string> { "Math", "Physics", "History", "Literature" },
                Answer = ""
            });
        }
        protected void OptionSelected(string option)
        {
            if (questionIndex == 0)
            {
                // If the question index is 0, it means it's the topic selection question
                // Call the TopicSelected method to handle the selection
                TopicSelected(option);
            }
            else
            {
                // Otherwise, handle checking of answers
                if (option == Questions[questionIndex].Answer)
                {
                    score++;
                }
            }
            questionIndex++;
        }

        protected void RestartQuiz()
        {
            score = 0;
            questionIndex = 0;
            LoadQuestions();
        }

        private void LoadThemeMathQuestions()
        {
            Question q1 = new Question
            {
                QuestionTitle = "What is the derivative of f(x) = 3x^2 + 2x - 5?",
                Options = new List<string>() { "6x + 2", " 6x - 2", "3x + 2", " 3x - 2" },
                Answer = "6x+2"
            };
            Question q2 = new Question
            {
                QuestionTitle = "In a geometric sequence, the 4th term is 81 and the 7th term is 729. What is the common ratio?",
                Options = new List<string>() { "3", "2", "9", "4" },
                Answer = "3"
            };
            Question q3 = new Question
            {
                QuestionTitle = "If a right triangle has one leg of length 8 and a hypotenuse of length 10, what is the length of the other leg?",
                Options = new List<string>() { "6", "7", "8", "9" },
                Answer = "6"
            };
            Question q4 = new Question
            {
                QuestionTitle = "Solve for x: log₂(x + 2) = 3",
                Options = new List<string>() { "6", "8", "14", "10" },
                Answer = "6"
            };
            Questions.AddRange(new List<Question> { q1, q2, q3, q4 });
        }
        private void LoadThemePhysicsQuestions()
        {
            Question q1 = new Question
            {
                QuestionTitle = "What is the SI unit of electric charge?",
                Options = new List<string>() { "Ampere (A)", " Volt (V)", " Coulomb (C)", "Ohm (Ω)" },
                Answer = "Coulomb(C)"
            };

            Question q2 = new Question
            {
                QuestionTitle = "According to Newton's second law of motion, what is the relationship between force, mass, and acceleration?",
                Options = new List<string>() { " F = m/a", " F = ma", "F = m + a", "F = m - a" },
                Answer = " F = ma"
            };

            Question q3 = new Question
            {
                QuestionTitle = "What is the conservation law that states that the total energy of an isolated system remains constant over time?",
                Options = new List<string>() { "Newton's Law of Gravitation", " Ohm's Law", "Kepler's Laws of Planetary Motion", "Law of Conservation of Energy" },
                Answer = "Law of Conservation of Energy"
            };

            Question q4 = new Question
            {
                QuestionTitle = "Which of the following is an example of a vector quantity?",
                Options = new List<string>() { "Speed", "Mass", "Distance", "Velocity" },
                Answer = "Velocity"
            };
            Questions.AddRange(new List<Question> { q1, q2, q3, q4 });
        }
        private void LoadThemeHystoryQuestions()
        {
            Question q1 = new Question
            {
                QuestionTitle = "Who was the first female Prime Minister of the United Kingdom?",
                Options = new List<string>() { "Margaret Thatcher", "Indira Gandhi", "Angela Merkel", "Golda Meir" },
                Answer = "Margaret Thatcher"
            };
            Question q2 = new Question
            {
                QuestionTitle = "The Magna Carta, signed in 1215, limited the power of which monarch in England?",
                Options = new List<string>() { "Henry VIII", "William the Conqueror", "King John", "Richard the Lionheart" },
                Answer = "King John"
            };
            Question q3 = new Question
            {
                QuestionTitle = "What event sparked the beginning of World War I?",
                Options = new List<string>() { "Assassination of Archduke Franz Ferdinand", "Bombing of Pearl Harbor", "Treaty of Versailles", "Battle of Stalingrad" },
                Answer = "Assassination of Archduke Franz Ferdinand"
            };
            Question q4 = new Question
            {
                QuestionTitle = "The Russian Revolution of 1917 led to the overthrow of which ruling family?",
                Options = new List<string>() { "Romanov", "Habsburg", "Bourbon", "Hohenzollern" },
                Answer = "Romanov"
            };
            Questions.AddRange(new List<Question> { q1, q2, q3, q4 });
        }
        private void LoadThemeLogicQuestions()
        {
            Question q1 = new Question
            {
                QuestionTitle = "Who wrote the novel \"To Kill a Mockingbird\"?",
                Options = new List<string>() { "F. Scott Fitzgerald", "Harper Lee", " John Steinbeck", "J.D. Salinger" },
                Answer = "F. Scott Fitzgerald"
            };

            Question q2 = new Question
            {
                QuestionTitle = "In which Shakespearean play does the character Hamlet famously deliver the soliloquy beginning with \"To be or not to be\"?",
                Options = new List<string>() { "Romeo and Juliet", "Macbeth", "Hamlet", "Othello" },
                Answer = "Hamlet"
            };

            Question q3 = new Question
            {
                QuestionTitle = "Who is the author of the dystopian novel \"1984\"?",
                Options = new List<string>() { "George Orwell", " Aldous Huxley", " Ray Bradbury", "Margaret Atwood" },
                Answer = "George Orwell"
            };

            Question q4 = new Question
            {
                QuestionTitle = "Which novel begins with the line, \"Call me Ishmael\"?",
                Options = new List<string>() { "Moby-Dick by Herman Melville", "The Catcher in the Rye by J.D. Salinger", "Pride and Prejudice by Jane Austen", "The Great Gatsby by F. Scott Fitzgerald" },
                Answer = "Moby-Dick by Herman Melville"
            };
            Questions.AddRange(new List<Question> { q1, q2, q3, q4 });
        }
    }
}