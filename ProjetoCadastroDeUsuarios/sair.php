<?php
session_start();
session_unset();
session_destroy();
if (isset($_COOKIE['PHPSESSID'])) {
    setcookie('PHPSESSID', '', time() - 3600, '/', '', 0, true);
}
header('Location: index.php');
exit();
?>
