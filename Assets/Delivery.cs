using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delivery : MonoBehaviour
{
   [SerializeField] Color32 hasPackageColor=new Color32(1,1,1,1);
   [SerializeField] Color32 noPackageColor=new Color32(1,1,1,1);
   [SerializeField] float destroyDelay=0.5f;
   bool hasPackage;
   SpriteRenderer spriteRenderer;
   
   void Start() {
      spriteRenderer = GetComponent<SpriteRenderer>();
   }
   void OnCollisionEnter2D(Collision2D other) {
      // Debug.Log("Bammm!!!");
   }
   int PackageDelivered=0;
   void OnTriggerEnter2D(Collider2D other) {
      if(other.tag=="Package" && !hasPackage){
         Debug.Log("Package Picked");
         hasPackage=true;
         spriteRenderer.color=hasPackageColor;
         Destroy(other.gameObject,destroyDelay);
      }
      if(other.tag=="Customer" && hasPackage){
         PackageDelivered++;
         Debug.Log("Package Delivered");
         spriteRenderer.color=noPackageColor;
         hasPackage=false;
         if(PackageDelivered==3){
            Invoke("ReloadScene",0.5f);
         }
      }
   }
   void ReloadScene(){
      SceneManager.LoadScene(0);
   }
}
