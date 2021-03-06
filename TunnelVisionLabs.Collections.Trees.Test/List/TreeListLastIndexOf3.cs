﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace TunnelVisionLabs.Collections.Trees.Test.List
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    /// <summary>
    /// Tests for <see cref="TreeList{T}.LastIndexOf(T, int, int)"/>, derived from tests for
    /// <see cref="List{T}.LastIndexOf(T, int, int)"/> in dotnet/coreclr.
    /// </summary>
    public class TreeListLastIndexOf3
    {
        [Fact(DisplayName = "PosTest1: The generic type is int")]
        public void PosTest1()
        {
            int[] iArray = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                iArray[i] = i;
            }

            TreeList<int> listObject = new TreeList<int>(iArray);
            int ob = Generator.GetInt32(0, 1000);
            int result = listObject.LastIndexOf(ob, 999, 1000);
            Assert.Equal(ob, result);
        }

        [Fact(DisplayName = "PosTest2: The generic type is type of string")]
        public void PosTest2()
        {
            string[] strArray = { "apple", "dog", "banana", "chocolate", "dog", "food" };
            TreeList<string> listObject = new TreeList<string>(strArray);
            int result = listObject.LastIndexOf("dog", 3, 3);
            Assert.Equal(1, result);
        }

        [Fact(DisplayName = "PosTest3: The generic type is a custom type")]
        public void PosTest3()
        {
            MyClass myclass1 = new MyClass();
            MyClass myclass2 = new MyClass();
            MyClass myclass3 = new MyClass();
            MyClass[] mc = new MyClass[3] { myclass1, myclass2, myclass3 };
            TreeList<MyClass> listObject = new TreeList<MyClass>(mc);
            int result = listObject.LastIndexOf(myclass3, 2, 1);
            Assert.Equal(2, result);
        }

        [Fact(DisplayName = "PosTest4: There are many element in the list with the same value")]
        public void PosTest4()
        {
            string[] strArray = { "apple", "banana", "chocolate", "banana", "banana", "dog", "banana", "food" };
            TreeList<string> listObject = new TreeList<string>(strArray);
            int result = listObject.LastIndexOf("banana", 2, 3);
            Assert.Equal(1, result);
        }

        [Fact(DisplayName = "PosTest5: Do not find the element")]
        public void PosTest5()
        {
            int[] iArray = { 1, 9, -8, 3, 6, -1, 8, 7, -11, 2, 4 };
            TreeList<int> listObject = new TreeList<int>(iArray);
            int result = listObject.LastIndexOf(-11, 6, 4);
            Assert.Equal(-1, result);
        }

        [Fact(DisplayName = "NegTest1: The index is negative")]
        public void NegTest1()
        {
            int[] iArray = { 1, 9, -11, 3, 6, -1, 8, 7, 1, 2, 4 };
            TreeList<int> listObject = new TreeList<int>(iArray);
            Assert.Throws<ArgumentOutOfRangeException>(() => listObject.LastIndexOf(-11, -4, 3));
        }

        [Fact(DisplayName = "NegTest2: index and count do not specify a valid section in the List")]
        public void NegTest2()
        {
            int[] iArray = { 1, 9, -11, 3, 6, -1, 8, 7, 1, 2, 4 };
            TreeList<int> listObject = new TreeList<int>(iArray);
            Assert.Throws<ArgumentOutOfRangeException>(() => listObject.LastIndexOf(-11, 6, 10));
        }

        [Fact(DisplayName = "NegTest3: The count is a negative number")]
        public void NegTest3()
        {
            int[] iArray = { 1, 9, -11, 3, 6, -1, 8, 7, 1, 2, 4 };
            TreeList<int> listObject = new TreeList<int>(iArray);
            Assert.Throws<ArgumentOutOfRangeException>(() => listObject.LastIndexOf(-11, 1, -1));
        }

        public class MyClass
        {
        }
    }
}
