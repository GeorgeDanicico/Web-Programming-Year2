<?php
  session_start();
  require_once "configuration.php";

  global $connection;
  $oldcount =$_SESSION['oldprojectcount'];
  $str = "SELECT count(*) as total from project";
  //  echo $str;
  $result = mysqli_query($connection, $str);
  $data=$result->fetch_assoc();
  if ($oldcount < $data['total']){
    echo '<script language="javascript">';
echo 'alert("updates!")';
echo '</script>';
  }
 die();
  ?>