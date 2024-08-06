using System;
using System.Collections.Generic;

public class DoublyLinkedList
{
    private Node head;
    private Node tail;
    private Node current;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        current = null;
    }

    public void AddTrack(string track)
    {
        Node newNode = new Node(track);
        if (head == null)
        {
            head = tail = current = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
    }

    public bool RemoveTrack(string track)
    {
        Node node = head;
        while (node != null)
        {
            if (node.Track == track)
            {
                if (node.Prev != null)
                {
                    node.Prev.Next = node.Next;
                }
                if (node.Next != null)
                {
                    node.Next.Prev = node.Prev;
                }
                if (node == head)
                {
                    head = node.Next;
                }
                if (node == tail)
                {
                    tail = node.Prev;
                }
                if (node == current)
                {
                    current = node.Next != null ? node.Next : node.Prev;
                }
                return true;
            }
            node = node.Next;
        }
        return false;
    }

    public string NextTrack()
    {
        if (current != null && current.Next != null)
        {
            current = current.Next;
            return current.Track;
        }
        return null;
    }

    public string PrevTrack()
    {
        if (current != null && current.Prev != null)
        {
            current = current.Prev;
            return current.Track;
        }
        return null;
    }

    public void ShuffleTracks()
    {
        List<string> tracks = new List<string>();
        Node node = head;
        while (node != null)
        {
            tracks.Add(node.Track);
            node = node.Next;
        }
        var rnd = new Random();
        for (int i = tracks.Count - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            string temp = tracks[i];
            tracks[i] = tracks[j];
            tracks[j] = temp;
        }
        head = tail = current = null;
        foreach (var track in tracks)
        {
            AddTrack(track);
        }
    }

    public List<string> GetTracks()
    {
        List<string> tracks = new List<string>();
        Node node = head;
        while (node != null)
        {
            tracks.Add(node.Track);
            node = node.Next;
        }
        return tracks;
    }

    public string CurrentTrack()
    {
        return current?.Track;
    }
}
