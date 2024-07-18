using System;
using System.Collections.Generic;
using System.Linq;

namespace Bootstrapper.Data
{
  [Serializable]
  public class PlayerData
  {
    /// Player data for saving
    public string URL;

    public List<CategoryDto> categories = new();
    public string name = "";
    public int successQuizSeries;
    public bool straightQuiz;
    public int totalQuiz;
    public int passedQuiz;
    public int failedQuiz;

    public bool TryGetCategory(string name, out CategoryDto dto)
    {
      dto = categories.FirstOrDefault(c => c.name == name);
      return dto != null;
    }
  }

  [System.Serializable]
  public class CategoryDto
  {
    public string name;
    public int rightAnswers;
  }
}