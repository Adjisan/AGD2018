using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	private int health;
	private int steps;
	private int damage;
	private Type myClass;
	private bool activated = false;
	private bool selected = false;

	public Unit(Type myClass, int health, int steps, int damage){
		this.myClass = myClass;
		this.health = health;
		this.steps = steps;
		this.damage = damage;
	}
	void DoDamage(int damage){
		this.health -= damage;
	}
	void SetActivated(bool activated){
		this.activated = activated;
	}
	bool GetActivated(){
		return this.activated;
	}
	void SetSelected(bool selected){
		this.selected = selected;
	}
	bool GetSelected(){
		return this.selected;
	}
}
public enum Type {Archer, Healer, Tank, Swordsman};