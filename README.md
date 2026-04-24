
**Prefab Architecture**

To ensure the spawner functions correctly, the Track Segment Prefab must follow a specific structure:

- Origin (0,0,0): The left-most point of your segment should be at local zero.

- EndPoint: An empty GameObject placed at the far right of the segment.

  - Note: The distance between the Origin and the EndPoint must equal the segmentLength value in the script.

- Static Elements: Ground, walls, and decorative assets should be children of this prefab.

**Technical Overview**

Script Logic: The Queue SystemThe script utilizes a Queue<GameObject> to keep track of segments currently visible or near the player:

1. Spawn: At start, the script populates the world with an initial set of segments.
2. Monitor: Every frame, it checks if the player's $X$ position has exceeded the boundary of the oldest segment (activeSegments.Peek()).
3. Recycle: Once a segment is behind the player, it is "Dequeued" (removed from the front), moved to the current spawnX position at the front of the line, and "Enqueued" (added back to the end).

**Setup Instructions**

1. Prepare the Prefab: Create your environment chunk and save it as a Prefab. Ensure the width is consistent (e.g., exactly 20 units).

2. Initialize Spawner: * Create an empty GameObject in your scene named EnvironmentManager.
    - Attach the EnvironmentSpawner script.

    - Drag your Player object and Segment Prefab into the Inspector slots.

3. Configure Units: Set the Segment Length to match the actual width of your art assets to avoid gaps or overlapping.
