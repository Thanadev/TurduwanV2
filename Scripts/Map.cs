using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {

	public GameObject tracer;
	List<Cell> cells;

	// Use this for initialization
	void Start () {
		cells = new List<Cell>();
		generateMap();
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void generateMap () {
		RaycastHit[] hits;
		for (int y = 0; y > -114; y-= 1) {
			for (int x = 0; x < 114; x+= 1) {
				hits = Physics.RaycastAll(tracer.transform.position + new Vector3(x, 0, y), -Vector3.up);
				foreach (RaycastHit hit in hits) {
					if (hit.collider.CompareTag("MapElement")) {
						GameObject toInstantiate = Resources.Load<GameObject>("Prefabs/Cell");
						toInstantiate = GameObject.Instantiate(toInstantiate, hit.point, Quaternion.identity) as GameObject;
						Cell cell = toInstantiate.GetComponent<Cell>();
						cell.Position = new Vector2(x, y);
						cells.Add(cell);
					}
				}
			}
		}
	}

	public Cell findCell (Vector2 position) {
		foreach (Cell cell in cells) {
			if (cell.Position == position) {
				return cell;
			}
		}

		return null;
	}
}
