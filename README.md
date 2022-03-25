# BinaryTreeDemo_Projekt
A little school exercise, just for fun


Übung:

Erstelle mit dotnet new xunit ein neues Projekt in einem Ordner mit dem Namen BinaryTreeDemo. Füge danach eine Klasse Node ein. Sie repräsentiert einen Knoten eines binären Baumes.

Bei einem binärem Baum hat ein Knoten 2 Felder: left und right. Ist ein Wert (z. B. eine Zahl) kleiner als der bestehende Wert des Knotens, wird der Wert auf der linken Seite eingehängt. Ist der Wert größer, so wird er in der rechten Hälfte eingehängt.

Auf https://www.cs.usfca.edu/~galles/visualization/BST.html findet sich eine nette Visualisierung des Einhängens.

Schreibe eine generische Klasse Node, die einen Knoten samt Unterknotenverwalten kann. Beachte dabei folgende Überlegungen

Die Klasse hat ein private readonly Feld _value.
Die Klasse hat zwei private Felder vom Typ Node: _left und _right.
Der zu verwaltende Wert soll generisch sein, muss aber mit CompareTo() vergleichen werden. Überlege daher ein type constraint.
Es gibt eine Methode Add(), die den übergebenen Wert zum Rootknoten gemäß der Animation hinzufügt.
Es gibt eine Methode ToOrderedList(), die eine Liste mit den aufsteigend sortierten Elementen zurückgibt.
Am Besten ist es, dass die Methode ToOrderedList() eine private Methode TraverseTree(list) mit einer leeren Liste aufruft. Die Methode TraverseTree(list) hängt dann die Elemente in der richtige Reihenfolge rekursiv ein. Die Methode kommt mit 2 if Statements und 3 Anweisungen aus.
Schreibe eine Methode Exists(value), die Überprüft ob ein Wert im Binary Tree vorhanden ist.
Füge zur Kontrolle die untenstehende Klasse NodeTests ein und prüfe, ob alle Tests erfolgreich durchlaufen.
@David Ankenbrand
