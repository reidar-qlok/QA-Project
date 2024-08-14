using Azure;
using Azure.AI.Language.QuestionAnswering;

namespace QA_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This example requires environment variables named "LANGUAGE_KEY" and "LANGUAGE_ENDPOINT"
            Uri endpoint = new Uri("https://langservmodel222.cognitiveservices.azure.com/");
            AzureKeyCredential credential = new AzureKeyCredential("ca6773945c28487e9b6af149ee86420d");
            string projectName = "LearnFAQ";
            string deploymentName = "production";

            //string question = "How can i learn more about microsoft certifications";

            QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
            QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);
            Console.WriteLine("Ask a question, type exit to quit.");

            while (true)
            {
                Console.WriteLine("Q: ");
                string question = Console.ReadLine();
                if (question.ToLower() == "exit")
                {
                    break;
                }
                try
                {
                    Response<AnswersResult> response = client.GetAnswers(question, project);
                    foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
                    {
                        Console.WriteLine($"Q:{question}");
                        Console.WriteLine($"A:{answer.Answer}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Request error: {ex.Message}");
                }
            }
        }
    }
}
