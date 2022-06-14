<?php
  session_start();
  require_once "configuration.php";

  global $connection;
  $myUser =$_SESSION['myUser'];
  $devname= $_GET["developer"];
  $projectname = $_GET["project"];

  $str = "SELECT * from softwaredeveloper where name='".$devname."';";
//  echo $str;
    $result = mysqli_query($connection, $str);

//echo "<html><body>";
if ($result->num_rows > 0) {
  // the developer exists
    $devId = $result->fetch_assoc()['id'];
    $str1 = "SELECT * from project where name='".$projectname."';";
   //  echo $str;
      $result1 = mysqli_query($connection, $str1);

    if ($result1->num_rows > 0) {

    $row1 = $result1->fetch_assoc() ;
    $idToUpdate = $row1['id'];
    $oldSub = $row1['members'];
    $array = explode(';', $oldSub);
    $newSub="";
    $found=false;
    foreach($array as $sub){
        if($sub != ''){
        
          if (strcmp($sub, $devname) == 0) {
              if(strcmp($newSub, "")) $newSub = $newSub.";";
              $found=true;
              $newSub = $newSub.$sub;
          }
          else{
            if(strcmp($newSub, "")) $newSub = $newSub.";";
              $newSub = $newSub.$sub;
          }
        }
    }

    if ($found == false) {
      if(strcmp($newSub, "")) $newSub = $newSub.";";
              $newSub = $newSub.$devname;
    }
    $str = "UPDATE project set members = '".$newSub."' where id =".$idToUpdate.";";
    echo $str;
    $result = mysqli_query($connection, $str);
  } else {
    //  echo $str;
    $newSub = $devname;
    echo $newSub;
    $str = "INSERT INTO project(projectmanagerid, name, description, members) values (".$devId.", '".$projectname."', 
    'description', '".$newSub."')";
    echo $str;
    $result = mysqli_query($connection, $str);
  }
    
}

//echo "</body></html>";
mysqli_close($connection);




  header("Location: http://localhost:8080/index/login.php?username=".$myUser);
    die();
  ?>