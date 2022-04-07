using System;
using System.Collections.Generic;
using Xunit;

namespace BinaryTreeDemo_Projekt
{
    public class NodeTests
    {
        [Fact]
        public void CheckOrderedListCountTest()
        {
            var root = new Node<int>(4);
            root.Add(6);
            root.Add(1);
            root.Add(8);
            root.Add(4);
            List<int> result = root.ToOrderedList();
            Assert.True(result.Count == 5);
        }

        [Fact]
        public void CheckOrderedListSortTest()
        {
            var root = new Node<int>(4);
            root.Add(6);
            root.Add(1);
            root.Add(8);
            root.Add(4);
            List<int> result = root.ToOrderedList();
            Assert.True(System.Text.Json.JsonSerializer.Serialize(result) == "[1,4,4,6,8]");
        }

        [Fact]
        public void CheckExistsWithExistingValueTest()
        {
            var root = new Node<int>(4);
            root.Add(6);
            root.Add(1);
            root.Add(8);
            root.Add(4);
            Assert.True(root.exists(8));
        }

        [Fact]
        public void CheckExistsWithNonExistingValueTest()
        {
            var root = new Node<int>(4);
            root.Add(6);
            root.Add(1);
            root.Add(8);
            root.Add(4);
            Assert.False(root.exists(7));
        }

        [Fact]
        public void CheckOrderedStringListSortTest()
        {
            var root = new Node<string>("A");
            root.Add("S");
            root.Add("D");
            root.Add("F");
            root.Add("G");
            List<string> result = root.ToOrderedList();
            Assert.True(System.Text.Json.JsonSerializer.Serialize(result) == @"[""A"",""D"",""F"",""G"",""S""]");
        }

        [Fact]
        public void Eigen_Check_Left_Right_Logic() // eigener Unit Test um Left-Right Logik zu checken
        {
            var root = new Node<int>(4);
            root.Add(6);
            root.Add(1);
            root.Add(8);
            root.Add(4);
            int result1 = root._right.value;
            int r1C = 6;

            int result2 = root._left.value;
            int r2C = 1;

            int result3 = root._right._right.value;
            int r3C = 8;

            int result4 = root._right._left.value;
            int r4C = 4;

            bool result = (result1 == r1C) && (result2 == r2C) && (result3 == r3C) && (result4 == r4C);
            Assert.True(result == true);

        }


    }
}
