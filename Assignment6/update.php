<?php
  $user = 'root';
  $pass = '';
  $db = 'vacations';

  $conn = new mysqli('localhost', $user, $pass, $db) or die("unable to connect to database");
  echo 'connect </br>';

  $id = (int) $_POST["id"];
  $cost = (int) $_POST["cost"];

  $sql = "UPDATE destinations SET
    estimated_cost='$cost'
    where id=$id
  ";

  if ($conn->query($sql) === TRUE) {
    echo "Destination updated successfully";
  } else {
    echo "Error: " . $sql . "<br>" . $conn->error;
  }

  $conn->close();
?>