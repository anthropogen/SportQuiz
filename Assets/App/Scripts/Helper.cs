using System;

public static class Helper
{
  public const int EasyQuestionsNum = 5;
  public const int MediumQuestionsNum = 7;
  public const int HardQuestionsNum = 10;

  public static int GetQuestionsNumFor(Difficult difficult)
  {
    return difficult switch
    {
      Difficult.Easy => EasyQuestionsNum,
      Difficult.Medium => MediumQuestionsNum,
      Difficult.Hard => HardQuestionsNum,
      _ => throw new ArgumentOutOfRangeException(nameof(difficult), difficult, null)
    };
  }
}