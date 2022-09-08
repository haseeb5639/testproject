namespace Firebase.Sample.Analytics { 
   using Firebase;
    using Firebase.Analytics;
    using Firebase.Extensions; 
   using System; 
   using System.Threading.Tasks; 
   using UnityEngine; 

 
  // Handler for UI buttons on the scene.  Also performs some 
  // necessary setup (initializing the firebase app, etc) on 
  // startup. 
   public class GRS_FirebaseHandler : MonoBehaviour { 

		DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
	    protected bool firebaseInitialized = false;

        // Start is called before the first frame update
       
        void Start()
		{
            Debug.unityLogger.logEnabled = true;
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => { 
			dependencyStatus = task.Result; 
			if (dependencyStatus == DependencyStatus.Available) { 
			InitializeFirebase(); 
			} else { 
			Debug.Log(" GG >>Could not resolve all Firebase dependencies: " + dependencyStatus); 
         } 
		}); 

		}

		void InitializeFirebase() {
            Debug.Log("GG >>Enabling data collection Firebase.");
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);


            //Debug.Log("Set user properties."); 
            //// Set the user's sign up method. 
            //FirebaseAnalytics.SetUserProperty( 
            //FirebaseAnalytics.UserPropertySignUpMethod, 
            //"Google"); 
            //// Set the user ID. 
            //FirebaseAnalytics.SetUserId("uber_user_510"); 
            //// Set default session duration values. 
            //FirebaseAnalytics.SetMinimumSessionDuration(new TimeSpan(0, 0, 10)); 
            //FirebaseAnalytics.SetSessionTimeoutDuration(new TimeSpan(0, 30, 0)); 
            firebaseInitialized = true;
            GRS_AdIDs.Check_Firebase= true;
            //LevelManegs.firebase = true;
            //GlobalScripts.firebase = true;
        } 

   }
}
