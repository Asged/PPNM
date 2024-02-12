using System;
using static System.Console;

public class vec(){
    public double x,y,z; //vector components
    //...

    public vec(){
        x=y=z=0;
    }

    public vec(double x, double y, double z){
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static vec operator*(vec v, double c){
        return new vec(c*v.x,c*v.y,c*v.z);
    }

    public static vec operator*(double c, vec v){
        return v*c;
    }

    public static vec operator+(vec v, vec u){
        return new vec(v.x+u.x, v.y+u.y, v.z+u.z)
    }

    public static vec operator-(vec u){
        return new vec(-u.x,-u.y,-u.z)
    }

    public static vec operator-(vec v, vec u){
        return new vec(v.x-u.x, v.y-u.y, v.z-u.z)
    }

    public void print(string s){
        Write($"{x} {y} {z}");
    }

    public void print(){
        this.print("");
    }

    public double dot(vec other){
        return this.x*other.x + this.y*other.y + this.z*other.z;
    }

    public static double dot(vec v, vec u){
        return v.x*u.x, v.y*u.y, v.z*u.z;
    }

    
}