﻿using UnityEngine;
using System.Collections;

public class Gemstone : MonoBehaviour {
	public float xOffset = -4.0f;  //x方向的偏移
	public float yOffset = -1.5f;  //y方向的偏移
	public int rowIndex = 0;       //行号
	public int columnIndex = 0;    //列号

	public GameObject[] gemstoneBgs;  //宝石(gemstone)的数组
	public int gemstoneType;  //宝石(gemstone)的类型
	public GameController gameController;
	public SpriteRenderer spriteRenderer;
	public bool isSelected{
		set{
			if(value){
				spriteRenderer.color = Color.red;   
			}else{
				spriteRenderer.color = Color.white;
			}
		}
	}


	private GameObject gemstoneBg;
	// Use this for initialization
	void Awake(){

	}

	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		spriteRenderer = gemstoneBg.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdatePosition(int _rowIndex,int _columnIndex){    //调整gemstone(宝石）的位置
		rowIndex = _rowIndex;
		columnIndex = _columnIndex;
		this.transform.position = new Vector3 (columnIndex*1.2f + xOffset, rowIndex*1.2f + yOffset, 0);
	}

	public void TweenToPostion(int _rowIndex,int _columnIndex){
		rowIndex = _rowIndex;
		columnIndex = _columnIndex;
		iTween.MoveTo (this.gameObject, iTween.Hash ("x",columnIndex * 1.2f + xOffset,"y",rowIndex*1.2f + yOffset,"time",0.3f));
	}

	public void RandomCreateGemstoneBg(){ //生成随机的宝石类型
		if (gemstoneBg != null)
			return;
		gemstoneType = Random.Range (0, gemstoneBgs.Length);
		gemstoneBg = Instantiate(gemstoneBgs[gemstoneType]) as GameObject;
		gemstoneBg.transform.parent = this.transform;
	}

	public void OnMouseDown(){
		gameController.Select (this);
	}

	public void Dispose(){
		Destroy (this.gameObject);
		Destroy (gemstoneBg.gameObject);
		gameController = null;
	}
}
