﻿
public class Person
{
    string name;
    int age;
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }

    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}

