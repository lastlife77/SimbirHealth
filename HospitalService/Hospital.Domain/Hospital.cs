﻿namespace Hospital.Domain;

public class Hospital
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string ContactPhone { get; set; }

    public List<Room> Rooms { get; set; }
}
