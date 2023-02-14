using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class IonCanonStick : MonoBehaviour
{

    public GameObject targetLine;

    private Vector3 initialAngles;
    static readonly double tan_Pi_div_8 = Math.Sqrt(2.0) - 1.0;
    static int intX, intZ;

    // Start is called before the first frame update
    void Start()
    {
        initialAngles = this.transform.rotation.eulerAngles;
        Debug.Log("inital angles are " + initialAngles.x + ", " + initialAngles.y + " " + initialAngles.z);

        intX = (int)Math.Round(initialAngles.x);
        intZ = (int)Math.Round(initialAngles.z);
        Debug.Log("intX is: " + intX + " and intZ: " + intZ);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentAngles = this.transform.rotation.eulerAngles;
        Debug.Log("current angles are " + currentAngles.x + ", " + currentAngles.y + " " + currentAngles.z);
        int newX = (int)Math.Round(currentAngles.x);
        int newZ = (int)Math.Round(currentAngles.z);
        Enum theDir = GetDirection(new Point(intX, intZ), new Point(newX, newZ));
        Debug.Log("newX is: " + newX + " and newZ: " + newZ);
        Debug.Log("Current Direction is: " + theDir.ToString());
        int dirNum = theDir.GetHashCode();
     //   targetLine.transform.eulerAngles = new Vector3(dirNum, targetLine.transform.eulerAngles.y, targetLine.transform.eulerAngles.z);
    }

    Enum GetDirection(Point start, Point end)
    {

        double dx = end.X - start.X;
        double dy = end.Y - start.Y;


        if (Math.Abs(dx) > Math.Abs(dy))
        {
            if (Math.Abs(dy / dx) <= tan_Pi_div_8)
            {
                return dx > 0 ? Direction.East : Direction.West;
            }

            else if (dx > 0)
            {
                return dy > 0 ? Direction.Northeast : Direction.Southeast;
            }
            else
            {
                return dy > 0 ? Direction.Northwest : Direction.Southwest;
            }
        }

        else if (Math.Abs(dy) > 0)
        {
            if (Math.Abs(dx / dy) <= tan_Pi_div_8)
            {
                return dy > 0 ? Direction.North : Direction.South;
            }
            else if (dy > 0)
            {
                return dx > 0 ? Direction.Northeast : Direction.Northwest;
            }
            else
            {
                return dx > 0 ? Direction.Southeast : Direction.Southwest;
            }
        }
        else
        {
            return Direction.Undefined;
        }


    }

    public enum Direction
    {
        North = 0,
        South = 180,
        East = 270,
        West = 90,
        Northeast = 315,
        Northwest = 45,
        Southeast = 225,
        Southwest = 135,
        Undefined = 0
    }

    public T GetEnumValue<T>(int intValue) where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
        {
            throw new Exception("T must be an Enumeration type.");
        }
        T val = ((T[])Enum.GetValues(typeof(T)))[0];

        foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
        {
            if (Convert.ToInt32(enumValue).Equals(intValue))
            {
                val = enumValue;
                break;
            }
        }
        return val;
    }
}
