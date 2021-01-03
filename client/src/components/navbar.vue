<template>
  <nav class="navbar sticky p-0 d-flex justify-content-between">
    <div class="col-2 col-sm-1 mr-4">
      <router-link class="navbar-brand" :to="{ name: 'Home' }">
        <div class="d-flex flex-column align-items-center">
          <img
            alt="logo"
            src="../assets/img/klogo.png"
            height="45"
          />
        </div>
      </router-link>
    </div>
    <div class="col-sm-5 col-md-6 d-flex align-items-center">
      <div class="input-group mt-2">
        <!-- <div class="input-group-prepend">
              <span class="input-group-text" id="inputGroup-sizing-default">Default</span>
            </div> -->
        <input type="text" class="form-control mb-2" aria-label="Default" aria-describedby="inputGroup-sizing-default">
      </div>
    </div>
    <div class="col-sm-1 col-md-2 p d-flex justify-content-end">
      <button
        class="btn btn-outline-primary text-uppercase"
        @click="login"
        v-if="!user.isAuthenticated"
      >
        Log in
      </button>
      <button
        class="btn btn-outline-primary text-uppercase"
        @click="logout"
        v-if="user.isAuthenticated"
      >
        Log out
      </button>
      <!-- <button @click="logout" v-else class="p-0 btn-bg border-light rounded text-light btn-block btn-sm">
        Log Out
      </button> -->
    </div>
    <!--

    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon" />
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item">
          <router-link :to="{ name: 'Home' }" class="nav-link">
            Home
          </router-link>
        </li>
        <li class="nav-item">
          <router-link :to="{ name: 'About' }" class="nav-link">
            About
          </router-link>
        </li>
      </ul>
      <span class="navbar-text">
        <button
          class="btn btn-outline-primary text-uppercase"
          @click="login"
          v-if="!user.isAuthenticated"
        >
          Login
        </button>

        <div class="dropdown" v-else>
          <div
            class="dropdown-toggle"
            @click="state.dropOpen = !state.dropOpen"
          >
            <img
              :src="user.picture"
              alt="user photo"
              height="40"
              class="rounded"
            />
            <span class="mx-3">{{ user.name }}</span>
          </div>
          <div
            class="dropdown-menu p-0 list-group w-100"
            :class="{ show: state.dropOpen }"
            @click="state.dropOpen = false"
          >
            <router-link :to="{ name: 'Profile' }">
              <div class="list-group-item list-group-item-action hoverable">
                Profile
              </div>
            </router-link>
            <div
              class="list-group-item list-group-item-action hoverable"
              @click="logout"
            >
              logout
            </div>
          </div>
        </div>
      </span>
    </div> -->
  </nav>
</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
export default {
  name: 'Navbar',
  setup() {
    const state = reactive({
      dropOpen: false
    })
    return {
      state,
      user: computed(() => AppState.user),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        await AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style scoped>
.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
}
.dropdown-menu.show {
  transform: scale(1);
}
.hoverable {
  cursor: pointer;
}
a:hover {
  text-decoration: none;
}
.nav-link{
  text-transform: uppercase;
}
.nav-item .nav-link.router-link-exact-active{
  color: var(--primary);
}
.navbar {
  background-color:#55efc4 ;
}
</style>
