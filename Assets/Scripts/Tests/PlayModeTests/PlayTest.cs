using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

namespace Tests
{

    
    public class PlayTest
    {
        public GameObject winTextObject;

        public Besek besek;

        public Gigas gigas;

        public Kuin kuin;

        public Besek besekPrefab = AssetDatabase.LoadAssetAtPath<Besek>("Assets/Prefabs/Besek.prefab");

        public Gigas gigasPrefab = AssetDatabase.LoadAssetAtPath<Gigas>("Assets/Prefabs/Gigas.prefab");

        public Kuin kuinPrefab = AssetDatabase.LoadAssetAtPath<Kuin>("Assets/Prefabs/Kuin.prefab");

        // False is a Pass as SetActive is set to False on this gameobject on start
        [Test]
        public void CheckWinTextObjectIsFalseOnStart()
        {
            Assert.False(winTextObject);
        }

        // True is a Fail as SetActive is set to False on this gameobject on start
        // I want this to fail. 
        [Test]
        public void CheckWinTextObjectIsTrueOnStart()
        {
            Assert.True(winTextObject);
        }

        // Check if Rotator Script is On Kuin Prefab
        [UnityTest]
        public IEnumerator RotatorScriptOnKuinPrefab()
        {
            // remove the default skybox.
            RenderSettings.skybox = null;
            // create a new root game object.
            var root = new GameObject();
            // add the camera component to our root game object.
            root.AddComponent(typeof(Camera));
            // get a ref to the cam.
            var camera = root.GetComponent<Camera>();
            // set the camera background color to cyan.
            camera.backgroundColor = Color.cyan;
            // add our gameobject with the camera to the scene by instantiating it
            root = GameObject.Instantiate(root);
            // Load the collectible prefab by using its path
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Kuin.prefab");
            // instantiate the prefab
            prefab = GameObject.Instantiate(prefab, new Vector3(0, 0, 10), new Quaternion(0, 180, 0, 0));
            // Wait for three seconds, as this gives u time to se the prefab in the scene if its an animation or something  
            yield return new WaitForSeconds(3f);
            // Our prefab has a script on it
            var script = prefab.gameObject.GetComponentInChildren<Rotator>();
            // asert that the script exists on the prefab
            Assert.IsTrue(script != null, "Rotator must be set on the Kuin.prefab.");
            // destroy to clean up the scene
            GameObject.Destroy(prefab);
            GameObject.Destroy(root);
        }

    }
}
