<?php
  $user = 'root';
  $pass = '';
  $db = 'vacations';

  $conn = new mysqli('localhost', $user, $pass, $db) or die("unable to connect to database");
  echo 'connect </br>';

  $id = (int) $_POST["id"];

  $sql = "DELETE FROM destinations
    where id=$id
  ";

  if ($conn->query($sql) === TRUE) {
    echo "Destination deleted successfully";
  } else {
    echo "Error: " . $sql . "<br>" . $conn->error;
  }

  $conn->close();
?>