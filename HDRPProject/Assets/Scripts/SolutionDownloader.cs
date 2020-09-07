using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class SolutionDownloader : MonoBehaviour
{
    private string address = "/Users/ben.fuller/Downloads";
    public int projectNum = 1;
    public int buildNum;

    public bool getLatestBuild = true;
    // Start is called before the first frame update
    void Start()
    {
        string fileName;
        string aUri;
        if (getLatestBuild == true)
        {
            fileName = "version.txt";
            if (projectNum == 0)
            {
                aUri = $"https://static.wrenkitchens.com/planner3d/{fileName}";
            }
            else
            {
                aUri = $"https://project-static.wrenkitchens.com/planner3d/project{projectNum}/{fileName}";
            }
            StartCoroutine(DownloadBuildVersion(aUri));
        }
        fileName = "Planner3D.zip";
        if (projectNum == 0)
        {
            aUri = $"https://static.wrenkitchens.com/planner3d/{buildNum}/{fileName}";
        }
        else
        {
            aUri = $"https://project-static.wrenkitchens.com/planner3d/project{projectNum}/{buildNum}/{fileName}";
        }
        StartCoroutine(DownloadFile(aUri));
    }

    IEnumerator DownloadFile(string aUri)
    {
        WebClient client = new WebClient();
        if(buildNum != 0)
        {
            client.DownloadFileCompleted += (sender, e) => FileReplacing(e);
            client.DownloadFileAsync(new Uri(aUri), $"{address}/download.zip");
            yield return null;
        }
    }
    
    private void FileReplacing(AsyncCompletedEventArgs e)
    {
        try
        {
            if (e.Error == null)
            {
                if (File.Exists($"{address}/Planner3D.zip"))
                {
                    File.Delete($"{address}/Planner3D.zip");
                }
                if(Directory.Exists($"{address}/Planner3D.app"))
                {
                    Directory.Delete($"{address}/Planner3D.app",true);
                }
                File.Move($"{address}/download.zip", $"{address}/Planner3D.zip");
                using (Process process = new Process())
                {
                    
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.FileName = "unzip";
                    process.StartInfo.WorkingDirectory = address;
                    process.StartInfo.Arguments = "Planner3D.zip";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.Start();
                    process.WaitForExit(1000 * 60 * 5);
                    Debug.Log(process.StandardError.ReadToEnd()); 
                    Debug.Log(process.StandardOutput.ReadToEnd());
                }

                //ZipFile.ExtractToDirectory($"{Application.dataPath}/Planner3D.zip",Application.dataPath);
                Debug.Log("Done Download");
            }
            else
            {
                if (File.Exists($"{address}/download.zip"))
                {
                    File.Delete($"{address}/download.zip");
                }
                Debug.Log("Download Failed");
            }

        }
        catch(Exception ex)
        {
            Debug.Log(ex);
            Debug.Log("Failed Replacing download.zip");
        }
    }

    IEnumerator DownloadBuildVersion(string aUri)
    {
        WebClient client = new WebClient();
        try
        {
            Stream myStream = client.OpenRead(aUri);
            if (myStream != null)
            {
                StreamReader sr = new StreamReader(myStream);
                buildNum = int.Parse(sr.ReadToEnd());
                sr.Close();
            }
        }
        catch
        {
            Debug.Log("Failed to Get Latest Build Number");
        }
        yield return null;
    }
}
