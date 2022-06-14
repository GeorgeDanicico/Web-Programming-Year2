<?php
// Array with names

  session_start();
  require_once "configuration.php";

  global $connection;
  $myUser =$_SESSION['myUser'];

  $q = $_REQUEST["q"];

  $sql = "SELECT * FROM softwaredeveloper";
  $result = $connection->query($sql);

  if ($result->num_rows > 0) {
    $array = array();

    while($row = $result->fetch_assoc()) {
      $obj = array(
        'id' => $row["id"], 
        'name' => $row['name'],
        'age' => $row['age'],
        'skills' => $row['skills'],
      );

      array_push($array, $obj);
    }
    echo json_encode($array);
  
  } else {
  echo json_encode(array());
  }


$a = array();
