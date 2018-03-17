# gilded-refuktor
yet another gilded rose

# constraints
1. cannot modify items collection
2. Cannot modify item

## approach
This time covered in tests intended to
1. bring out domain
2. pull out ocvered code into other methods
3. Really think about whether polymorphism earlier would of helped. (on the back of a drunken 
night of xp manchester)

## conclusion

Going polymorphic early made me break one of the key constraints.
With polymorphism i needed to take the origional input pass it through an adapter to act as an ACL - i mitakenly modified the items collection

Would that be a far better model? Yeah.
Should I of seen that i was about to break a constrain? Yeah

Do that means polymorphism was worse than switching based on type?

No, but it does mean i think it was a premature refactor. It caused change in 2 places at once but i only changed one.
I could easily of just used switches and then push the duplication up into polymorphism.

Does that mean i shouldn't of introduced polymorphism when i did?
I think so. But i feel like that is more a conclusion based on my failing at this approach.

I did another version of this with branching based upon the name of an item.
Dirty but just worked immediatley. 
