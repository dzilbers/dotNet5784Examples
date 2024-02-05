namespace WpfBinding;

using System.Collections.Generic;
using System;
using System.Collections;

public enum Levels { Beginner, AdvancedBeginner, Expert }

public class LevelsPO : IEnumerable
{
    private static readonly IEnumerable<Levels> s_categories = (Enum.GetValues(typeof(Levels)) as IEnumerable<Levels>)!;
    public IEnumerator GetEnumerator() => s_categories.GetEnumerator();
}