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
            Assert.True(root.Exists(8));
        }

        [Fact]
        public void CheckExistsWithNonExistingValueTest()
        {
            var root = new Node<int>(4);
            root.Add(6);
            root.Add(1);
            root.Add(8);
            root.Add(4);
            Assert.False(root.Exists(7));
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
    }
}
