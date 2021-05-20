using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionBetweenScenes : MonoBehaviour
{
    [SerializeField] private GameObject bufferImg;
    [SerializeField] private float seconds;
    [SerializeField] private Image Background;
    [SerializeField] Text header;
    
    private Coroutine fadeCR;
    private bool corutineHasEnded = false;
    
    private void Start()
    {
        Color beginColor = Background.color;
        beginColor.a = 0;
        Background.color = beginColor;
        //bufferImg.SetActive( false );
        if ( header != null ) {
          header.enabled = false;
        }
        //SceneReadyCallback( true );
    }
    
    //Cambiar por async
    private IEnumerator WaitToSetActive( string scene )
    {
        Scene lastScene = SceneManager.GetActiveScene();
        Scene currentScene = SceneManager.GetSceneByName( scene );

        if( lastScene != currentScene )
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync( scene, LoadSceneMode.Additive );

            asyncOperation.allowSceneActivation = false;
            SceneReadyCallback( false );   //<= pararle el async y que haga de segundos su corutina
            while( asyncOperation.progress < 0.9f )
            {
                if( asyncOperation.progress < 0.89f )
                {
                    Debug.Log( $"Loading progress: " + ( asyncOperation.progress * 100 ).ToString( "0.00" ) );
                    header.text = $"Loading progress: {( asyncOperation.progress * 100 ).ToString( "F0" )}%";
                }
                else if( asyncOperation.progress >= 0.89f )
                {
                    header.text = $"Loading your link. It's almost ready!";
                }
            }
            yield return new WaitUntil( () => corutineHasEnded );
            asyncOperation.allowSceneActivation = true;
            yield return new WaitUntil( () => lastScene.isLoaded );
            SceneManager.UnloadSceneAsync( lastScene );
            SceneManager.SetActiveScene( SceneManager.GetSceneByName( scene ) );
        }
        else
        {
            SceneReadyCallback( false );
            yield return new WaitUntil( () => corutineHasEnded );
            SceneManager.LoadScene( scene, LoadSceneMode.Single );

        }
    }

    private IEnumerator DoFade( bool fIn )
    {
        float t = 0;
        float fade;
        Color c;
        
        while ( t < 1 )
        {
            yield return null;
            t += Time.deltaTime / seconds;
            
            if ( fIn )
            {
                fade = Mathf.Lerp( 0, 1, t );
            }
            else
            {
                fade = Mathf.Lerp( 1, 0, t );
            }
            
            if ( t >= 0.5f )
            {
                //bufferImg.SetActive( fIn );
                if ( header != null )
                    header.enabled = fIn;
            }
            
            
            //else if (t< 0.5f) Debug.Log("Fading");
            c = Background.color;
            c.a = fade;
            Background.color = c;
        }
        
        corutineHasEnded = true;
        yield break;
    }
    
    public void LoadScene( string scene )
    {
        //DG.Tweening.DOTween.KillAll();
        if( !SceneManager.GetSceneByName( scene ).isLoaded )
        {
            StartCoroutine( WaitToSetActive( scene ) );
            return;
        }
        else
        {
            StartCoroutine( WaitToSetActive( scene ) );
            //SceneManager.LoadScene( scene, LoadSceneMode.Single );
            return;
        }
        //SceneManager.LoadScene( scene, LoadSceneMode.Additive );
    }
    
    public void SceneReadyCallback( bool ready )
    {
        corutineHasEnded = false;
        if ( fadeCR != null )
        {
            StopCoroutine( fadeCR );
        }
        if ( !ready && header != null )
        {
            header.text = "Loading..";
        }
        fadeCR = StartCoroutine( DoFade( !ready ) );
    }

    public void Quit()
    {
        Application.Quit();
    }

}
