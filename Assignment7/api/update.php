<?php
  header('Access-Control-Allow-Headers: Access-Control-Allow-Origin, Content-Type');
  header('Access-Control-Allow-Origin: *');
  header('Content-Type: application/json, charset=utf-8');

  $user = 'root';
  $pass = '';
  $db = 'vacations';

  $conn = new mysqli('localhost', $user, $pass, $db) or die("unable to connect to database");
  echo 'connect </br>';

  $json = file_get_contents('php://input');
  $array = json_decode($json);

  $id = (int) $array->id;
  $cost = (int) $array->estimated_cost;

  $stmt = $conn->prepare("UPDATE destinations SET
  estimated_cost=?
  where id=?");
  $stmt->bind_param('ii', $cost, $id);

  if ($stmt->execute() === TRUE) {
    echo "Destination updated successfully";
  } else {
    echo "Error: " . $sql . "<br>" . $conn->error;
  }

  $conn->close();
?>