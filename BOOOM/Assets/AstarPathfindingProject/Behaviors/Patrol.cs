using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Simple patrol behavior.
	/// This will set the destination on the agent so that it moves through the sequence of objects in the <see cref="targets"/> array.
	/// Upon reaching a target it will wait for <see cref="delay"/> seconds.
	///
	/// See: <see cref="Pathfinding.AIDestinationSetter"/>
	/// See: <see cref="Pathfinding.AIPath"/>
	/// See: <see cref="Pathfinding.RichAI"/>
	/// See: <see cref="Pathfinding.AILerp"/>
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_patrol.php")]
	public class Patrol : VersionedMonoBehaviour {
		/// <summary>Target points to move to in order</summary>
		public Transform[] targets;
		GameObject direction;
		public GameObject directionFolder;
		/// <summary>Time in seconds to wait at each target</summary>
		public float delay = 0;

		/// <summary>Current target index</summary>
		int index;
		public int distance;

		IAstarAI agent;
		float switchTime = float.PositiveInfinity;

		protected override void Awake () {
			base.Awake();
			directionFolder = GameObject.FindGameObjectWithTag("Direction");
			agent = GetComponent<IAstarAI>();
			direction = new GameObject("Destination");
			direction.transform.parent = directionFolder.transform;
			direction.transform.position = new Vector3(Random.Range(-distance, distance), Random.Range(-distance, distance), 0);
			targets = new Transform[1];
			targets[0] = direction.transform;

		}

		/// <summary>Update is called once per frame</summary>
		void Update () {

			if (distance == 0) distance = Random.Range(0, 75);
			bool search = false;

			// Note: using reachedEndOfPath and pathPending instead of reachedDestination here because
			// if the destination cannot be reached by the agent, we don't want it to get stuck, we just want it to get as close as possible and then move on.
			if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime)) {
				switchTime = Time.time + delay;
				float x = Random.Range(-distance, distance);
				float y = Random.Range(-distance, distance);
				direction.transform.position = new Vector3(x, y, 0);
				targets[0] = direction.transform;
				if(distance >0) distance--;
				
				

			}

			if (Time.time >= switchTime) {
				index = index + 1;
				search = true;
				switchTime = float.PositiveInfinity;
			}
			
			index = 0;//index % targets.Length;
			agent.destination = targets[index].position;

			if (search) agent.SearchPath();
		}
	}
}
