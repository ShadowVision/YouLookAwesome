using UnityEngine;
using System.Collections;

namespace ShadowVision{
	public class Utilities{
		
		//Utility Functions
		public static string padInt(int value, int numberOfDigits){
			return value.ToString ("D" + numberOfDigits.ToString ());
		}

	}
	public class GameHelpers{
		//Old School Directions
		public enum Direction{
			IDLE, UP, DOWN, LEFT, RIGHT, UP_RIGHT, DOWN_RIGHT, UP_LEFT, DOWN_LEFT 
		}
		public static Direction getDirectionFromVelocity(Vector2 vel, bool ignoreDiagonals = false, float minThreshold = .001f){
			//Check if object is moving at all
			if(Mathf.Abs(vel.x) < minThreshold && Mathf.Abs(vel.y) < minThreshold){
				return Direction.IDLE;
			}
			Direction basicDirection = getBasicDirectionFromVelocity(vel, minThreshold);
			if(ignoreDiagonals){
				return basicDirection;
			}else{
				//check all angles
				if(basicDirection == Direction.RIGHT){
					if(vel.y > minThreshold/2){
						return Direction.UP_RIGHT;
					}else if (vel.y < -minThreshold){
						return Direction.DOWN_RIGHT;
					}
				}else if(basicDirection == Direction.LEFT){
					if(vel.y > minThreshold/2){
						return Direction.UP_LEFT;
					}else if (vel.y < -minThreshold){
						return Direction.DOWN_LEFT;
					}
				}
			}
			//if we couldn't find any direction
			return basicDirection;
		}
		public static Direction getBasicDirectionFromVelocity(Vector3 vel, float minThreshold = .001f){
			//Check if object is moving at all
			if(Mathf.Abs(vel.x) < minThreshold && Mathf.Abs(vel.y) < minThreshold){
				return Direction.IDLE;
			}
			//Check UP DOWN LEFT RIGHT
			if(Mathf.Abs(vel.x) >= Mathf.Abs(vel.y)){
				//moving horizontally
				if(vel.x > 0){
					return Direction.RIGHT;
				}else{
					return Direction.LEFT;
				}
			}else{
				//moving vertically
				if(vel.y > 0){
					return Direction.UP;
				}else{
					return Direction.DOWN;
				}
			} 
		}

	}

}
