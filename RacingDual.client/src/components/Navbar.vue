<template>
  <nav class="">
    <div
      class="row gx-0 img"
      style="
        background-image: url('../../src/assets/img/freestock_1664404.gif');
      "
    >
      <div class="col-md-4 pt-2 blur"></div>
      <div class="col-md-4 text-center pt-3 blur">
        <h1 class="header-1 mx-5">DualRacing</h1>
      </div>
      <div class="col-md-4 text-end pt-3 blur"><Login /></div>
    </div>
    <div class="row gx-0">
      <div class="col-md-12 d-flex justify-content-around nav-effect header">
        <div class="navbar-info">
          <div class="">
            <ul id="navbar" class="">
              <li type="button" class="dropbtn p-3 rounded">Home</li>
              <div class="dropdown">
                <li type="button" class="dropbtn p-3 rounded">F1</li>
                <div class="dropdown-content">
                  <a href="#">Link 1</a>
                  <a href="#">Link 2</a>
                  <a href="#">Link 3</a>
                </div>
              </div>
              <div class="dropdown">
                <div class="dropdown">
                  <li type="button" class="dropbtn">Gt Racing</li>
                  <div class="dropdown-content">
                    <a href="#">Link 1</a>
                    <a href="#">Link 2</a>
                    <a href="#">Link 3</a>
                  </div>
                </div>
              </div>
              <div class="dropdown">
                <div class="dropdown">
                  <li type="button" class="dropbtn">Indy Racing</li>
                  <div class="dropdown-content">
                    <a href="#">Link 1</a>
                    <a href="#">Link 2</a>
                    <a href="#">Link 3</a>
                  </div>
                </div>
              </div>
              <div class="dropdown">
                <div class="dropdown">
                  <li type="button" class="dropbtn">Nascar</li>
                  <div class="dropdown-content">
                    <a href="#">Link 1</a>
                    <a href="#">Link 2</a>
                    <a href="#">Link 3</a>
                  </div>
                </div>
              </div>
              <li type="button" class="dropbtn p-3 rounded">Blogs</li>
              <li type="button" class="dropbtn p-3 rounded">Community</li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core';
import Pop from '../utils/Pop';
import { AppState } from '../AppState';
import { VueScrollFixedNavbar } from "vue-scroll-fixed-navbar";

export default {

  setup() {

    return {

    };

  },
};
</script>

<style scoped>
.info {
  justify-content: space-between;
}

ul#navbar {
  display: inline;
  /* Any other CSS you want */
}
ul#navbar li {
  display: inline;
}

li {
  cursor: pointer;
  margin-inline-end: 1em;
}

/* The container <div> - needed to position the dropdown content */
.dropdown {
  position: relative;
  display: inline-block;
}

/* Dropdown Content (Hidden by Default) */
.dropdown-content {
  display: none;
  position: absolute;
  background-color: #ffffff;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
  z-index: 1;
}

/* Links inside the dropdown */
.dropdown-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}

/* Change color of dropdown links on hover */
.dropdown-content a:hover {
  background-color: #ddd;
}

/* Show the dropdown menu on hover */
.dropdown:hover .dropdown-content {
  display: block;
}

/* Change the background color of the dropdown button when the dropdown content is shown */
.dropdown:hover .dropbtn {
  background-color: #616261;
  transition: 800ms;
  color: white;
}

.navbar-info {
  padding-top: 0.5em;
  background-color: #e10600;
}

.nav-effect {
  background-color: #e10600;
  border-bottom: 1px solid black;
  border-top: 1px solid black;
}

.img {
  /* background-image: url("../assets/img/freestock_1664404.gif"); */
  height: 10vh;
  width: 100%;
  background-position: center;
  background-size: cover;
}

.blur {
  background-color: rgba(25, 26, 27, 0.573);
  -webkit-backdrop-filter: blur(5px);
  backdrop-filter: blur(5px);
}

.header-1 {
  color: #ffffff;
  font-weight: bold;
  border-bottom: 2px solid #ffffff;
}

.header {
  position: relative;
  left: 0;
  height: 10vh;
  align-items: center;
  padding: 20px 80px;
  z-index: 1000;
  color: #ffffff;
  transition: all 0.6s ease-in-out;
}
</style>
