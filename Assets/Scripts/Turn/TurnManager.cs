using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace General {
    public class TurnManager : MonoBehaviour {
        [SerializeField] private int turn;
        [SerializeField] private int playerAmount;

        private List<ITurnStart> turnStarts;
        private List<ITurnEnd> turnEnds;
        
        private void Start() {
            turnStarts = transform.GetComponentsInChildren<ITurnStart>().ToList();
            
            var turn_end = this.GetComponents<ITurnEnd>();
            foreach (var item in turn_end) {
                item.TurnEnd();
            }
        }

        public void TurnStart() {
            
        }
        
        
        public void TurnEnd() {
            
        }
    }
}