using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour {

	public Transform agentPrefab;

	public int nAgents;

	public List<Agent> agents;

	public float bound;

	public float spawnR;

	void Start () {

		agents = new List<Agent>();
		spawn(agentPrefab, nAgents);

		agents.AddRange(FindObjectsOfType<Agent>());
	
	}
	
	void Update () {
	
	}

	void spawn(Transform prefab, int n){

		for(int i=0; i< n; i++){

			Instantiate(prefab,
			            new Vector3(Random.Range(-spawnR,spawnR),0, Random.Range(-spawnR,spawnR)),
	                      Quaternion.identity);
		}
	}

	public List<Agent> getNeigh(Agent agent, float radius){

		List<Agent> r = new List<Agent>();

		foreach(var otherAgent in agents){

			if(otherAgent == agent)
				continue;

			if(Vector3.Distance(agent.x, otherAgent.x) <= radius){
				r.Add(otherAgent);
			}
		}

		return r;
	}
}
